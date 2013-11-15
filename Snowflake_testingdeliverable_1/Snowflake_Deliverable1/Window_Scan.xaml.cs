using System;
using System.Globalization;
using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Kinect;
using System.Text;
using System.Text.RegularExpressions;

namespace Snowflake_UI_Mockup
{
    /// <summary>
    /// Interaction logic for WindowScan.xaml
    /// </summary>
    public partial class WindowScan : Window
    {
        /// <summary>
        /// Active Kinect sensor
        /// </summary>
        private KinectSensor sensor;

        /// <summary>
        /// Bitmap that will hold color information
        /// </summary>
        private WriteableBitmap colorBitmap;

        /// <summary>
        /// Intermediate storage for the depth data received from the camera
        /// </summary>
        private DepthImagePixel[] depthPixels;

        /// <summary>
        /// Intermediate storage for the depth data converted to color
        /// </summary>
        private byte[] colorPixels;

        /// <summary>
        /// Storage of all depth data that will later be compressed and sent to the cloud
        /// </summary>
        //private List<DepthImagePixel[]> depthFrames = new List<DepthImagePixel[]>();

        /// <summary>
        /// Boolean to determine if the window will be restarted.
        /// </summary>
        private bool restart = false;

        /// <summary>
        /// Boolean to determine if frames should be captured.
        /// </summary>
        private bool capture = false;

        private int minDepth = 30;
        private int maxDepth = 1000;

        public WindowScan()
        {
            InitializeComponent();
        }


        /// <summary>
        /// Execute startup tasks
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void ScanWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Look through all sensors and start the first connected one.
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.sensor = potentialSensor;
                    break;
                }
            }

            if (null != this.sensor)
            {
                // Turn on the depth stream to receive depth frames
                this.sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);

                // Allocate space to put the depth pixels we'll receive
                this.depthPixels = new DepthImagePixel[this.sensor.DepthStream.FramePixelDataLength];

                // Allocate space to put the color pixels we'll create
                this.colorPixels = new byte[this.sensor.DepthStream.FramePixelDataLength * sizeof(int)];

                // This is the bitmap we'll display on-screen
                this.colorBitmap = new WriteableBitmap(this.sensor.DepthStream.FrameWidth, this.sensor.DepthStream.FrameHeight, 96.0, 96.0, PixelFormats.Bgr32, null);

                // Set the image we display to point to the bitmap where we'll put the image data
                this.Image.Source = this.colorBitmap;

                // Add an event handler to be called whenever there is new depth frame data
                this.sensor.DepthFrameReady += this.SensorDepthFrameReady;

                // Start the sensor!
                try
                {
                    this.sensor.Start();
                }
                catch (IOException)
                {
                    this.sensor = null;
                }
            }

            if (null == this.sensor)
            {
                this.statusBarText.Text = Snowflake_Deliverable1.Properties.Resources.NoKinectReady;
            }
        }

        /// <summary>
        /// Event handler for Kinect sensor's DepthFrameReady event
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void SensorDepthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            using (DepthImageFrame depthFrame = e.OpenDepthImageFrame())
            {
                if (depthFrame != null)
                {
                    // Copy the pixel data from the image to a temporary array
                    //depthFrame.CopyDepthImagePixelDataTo(this.depthPixels);
                    this.depthPixels = depthFrame.GetRawPixelData();

                    // Get the min and max reliable depth for the current frame
                    //int minDepth = depthFrame.MinDepth;
                    //int maxDepth = depthFrame.MaxDepth;

                    // Convert the depth to RGB
                    int colorPixelIndex = 0;
                    for (int i = 0; i < this.depthPixels.Length; ++i)
                    {
                        // Get the depth for this pixel
                        short depth = depthPixels[i].Depth;

                        // To convert to a byte, we're discarding the most-significant
                        // rather than least-significant bits.
                        // We're preserving detail, although the intensity will "wrap."
                        // Values outside the reliable depth range are mapped to 0 (black).

                        // Note: Using conditionals in this loop could degrade performance.
                        // Consider using a lookup table instead when writing production code.
                        // See the KinectDepthViewer class used by the KinectExplorer sample
                        // for a lookup table example.
                        byte intensity = (byte)(depth >= minDepth && depth <= maxDepth ? depth : 0);

                        // Write out blue byte
                        this.colorPixels[colorPixelIndex++] = intensity;

                        // Write out green byte
                        this.colorPixels[colorPixelIndex++] = intensity;

                        // Write out red byte                        
                        this.colorPixels[colorPixelIndex++] = intensity;

                        // We're outputting BGR, the last byte in the 32 bits is unused so skip it
                        // If we were outputting BGRA, we would write alpha here.
                        ++colorPixelIndex;
                    }

                    // Write the pixel data into our bitmap
                    this.colorBitmap.WritePixels(
                        new Int32Rect(0, 0, this.colorBitmap.PixelWidth, this.colorBitmap.PixelHeight),
                        this.colorPixels,
                        this.colorBitmap.PixelWidth * sizeof(int),
                        0);

                    // Store the depth data if the user wanted the data captured.
                    //if (capture) this.depthFrames.Add(this.depthPixels);
                }
            }
        }

        /// <summary>
        /// Event handler for 'Restart' button click event, sets restart to true
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Button_Restart_Click(object sender, RoutedEventArgs e)
        {
            // Stop scanning.
            if (null != this.sensor)
            {
                this.sensor.Stop();
            }
            restart = true;
            this.Close();
        }

        /// <summary>
        /// Event handler for 'Close' button click event
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        /// <summary>
        /// Event handler for Window closing event
        /// </summary>
        /// <param name="sender">object sending the event</param>
        /// <param name="e">event arguments</param>
        private void Scan_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Stop scanning.
            if (null != this.sensor)
            {
                this.sensor.Stop();
            }

            // If restart is true start a new instance of the window.
            if (restart)
            {
                WindowScan ws = new WindowScan();
                ws.Show();
            }
        }

        private void Button_Start_Click(object sender, RoutedEventArgs e)
        {
            this.statusBarText.Text = @"Capturing depth data...";

            if (null != this.sensor)
            {
                this.sensor.Stop();
            }

            if (null == this.sensor)
            {
                this.statusBarText.Text = Snowflake_Deliverable1.Properties.Resources.ConnectDeviceFirst;
                return;
            }

            // Path for the photos.
            string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\KinectScans\";

            // Create directory.
            System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\KinectScans");

            // Get current time.
            string time = System.DateTime.Now.ToString("hh'-'mm'-'ss", CultureInfo.CurrentUICulture.DateTimeFormat);

            string path = Path.Combine(myDocuments, "DepthData-" + time + ".txt");
            StreamWriter sw = new StreamWriter(File.Open(path, FileMode.Create));
            for (int i = 0; i < depthPixels.Length; i++)
            {
                sw.Write(depthPixels[i].Depth);
                sw.Write(" ");
            }
            // Close binary writer.
            sw.Close();

            string path2 = Path.Combine(myDocuments, "DepthData-" + time + ".dat");
            BinaryWriter bw = new BinaryWriter(File.Open(path2, FileMode.Create));
            for (int i = 0; i < depthPixels.Length; i++)
            {
                if (depthPixels[i].Depth > maxDepth || depthPixels[i].Depth < minDepth) depthPixels[i].Depth = 0;
                bw.Write(depthPixels[i].Depth);
            }
            // Close binary writer.
            bw.Close();

            // Send raw depth data to the cloud.

            // URI for RESTful upload API call.
            string URI = @"http://snowflake.cloudapp.net/rawdata/upload";
            string result;
            using (var client = new WebClient())
            {
                byte[] result1 = client.UploadFile(URI, path2);
                string responseAsString = Encoding.Default.GetString(result1);
                result = responseAsString;
            }

            var stlKey = (new Regex("\"stl_key\": \"(.*)\"", RegexOptions.Compiled)).Match(result).Groups[1];

            string url = @"http://snowflake.cloudapp.net/stl/" + stlKey;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            // Indicate that the depth data was collected.
            this.statusBarText.Text = "Done! STL KEY: ";
            this.TextBox_STL.Text = stlKey.ToString();

            // Open file explorer to show the user their collected data.
            System.Diagnostics.Process.Start(myDocuments);

            // Turn off start and done to indicate that the user needs to restart or close.
            this.Button_Start.IsEnabled = false;
        }
    }
}
