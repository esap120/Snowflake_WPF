   M S B A M L   `   `   `  ����   Snowflake_Deliverable1$    Snowflake_UI_Mockup.WindowScan   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     �Name$
  Scan�� � Title$
 Scan��$	��780��$	��844�� � WindowStartupLocation$ CenterScreen=� � 
ResizeMode$ NoResize=� � 	Resources    KinectPurpleBrush �� Color  KinectTextFormat �� 
TargetType �� Property �� Value  KinectBlueBrush  KinectCheckBox	 �� 
TargetType
 �� Orientation �Name ��Name ��Name �� TextAlignment �� Triggers P� Property P� Value �� 
TargetName  SliderRepeatButtonStyle  HorizontalSliderThumbStyle J� SnapsToDevicePixels ��Name  KinectSlider � RowDefinitions m�Name m� Fill m� 	Placement �� CornerRadius ��Name ]�Name ]� DecreaseRepeatButton �� DecreaseLarge ]� IncreaseRepeatButton �� IncreaseLarge  ]� Thumb! n�Name  ResetButton  
MeshButton 	 KinectRadioButton 
 MediumGreyBrush��%B  &	        &	      &	 �     &	 �     7   7  &	 �    &	      7   &	 �    7   7  7  7  7  7  &	 �    7   7  &	 �
    7   7  &		 o    7   7  &	
 �    �� $ 	#ff52318f���� " ��.���  � ��$ Center=���  � ��$ Center=���  � ��$ Segoe UI)���  � ��$ 15(��� $ 	#ff00BCF2���� " ��.���  � �� �� "	 ��.R�� .+��� $
 
Horizontal=�
������ .+�� $ CheckBoxChecked��.+��� $ CheckedNormal��$��Images\CheckedNormal.png��$
��None=�$��Center=��� $ CheckedHover��$��Images\CheckedHover.png��$
��None=�$��Center=�$y�	Collapsed=�� $ CheckBoxUnchecked��$y�	Collapsed=�.+��� $ UncheckedNormal��$ ��Images\UncheckedNormal.png��$
��None=�$��Center=��� $ UncheckedHover��$��Images\UncheckedHover.png��$
��None=�$��Center=�$y�	Collapsed=��� $ CheckBoxText��#��z��$
 Left=�$��Center=�8��  $��15(�$��9,0,0,0q� P�  �@d�	IsChecked$ falseY�. ��� $ CheckBoxChecked�� � y�$ 	Collapsed=��� $ CheckBoxUnchecked�� � y�$ Visible=�P�  �@J�IsMouseOver . . ��� $ CheckedNormal�� � y�$ 	Collapsed=��� $ UncheckedNormal�� � y�$ 	Collapsed=��� $ CheckedHover�� � y�$ Visible=��� $ UncheckedHover�� � y�$ Visible=��� 8  $ CheckBoxText�� � ���� " ��.���  �@�OverridesDefaultStyle . ��  � �� .  ��  � |� .  ��  � �� �� "	 ��.R��� 
������ �� " n�.���  � |� .  ��  �@�OverridesDefaultStyle . ��  � ��$ 22����  � ��$ 11����  � ��8   ��  � �� �� "	 n�.R���  . .+��� $
 Body��$��11��$��22��#��z���� " ��.���  �@��IsPressAndHoldEnabled .  ��  � ��
 ���� ��  � ��8   ��  � �� �� "	 ��.R��� #��z��#��z��#��z�� . ._��  �� $
��Auto ��� $
��Auto �#��z���� $
��Auto �.+�m� $
 Tick��# z��$��4��$	 Top=�$��0��$y�Visible=��� $ TrackBackground��#��z��$ 1��$	��4.0��$	��5,0q�$��1��$��center=�._��� $��-6,-1q�.+��� $ PART_SelectionRange��#��� ��$	��4.0��#��� ��$	��1.0��$y�Hidden=�]� $ 
PART_Track��$��1�� �� #��Z 8��  �� #��Z 8��   n� $! Thumb��8��  P�  �@J�IsMouseOver . . ��� 8   � ���� 8  $ Thumb�� � ���� " ��.���  � �� �� "	 ��.R��� $
 
Horizontal=�
������ .+�� .+��� $ ResetNormal��$��Images\ResetNormal.png��$
��None=�$��Center=��� $ 
ResetHover��$��Images\ResetHover.png��$
��None=�$��Center=�$y�	Collapsed=��� $ 	ResetText��#��z��$
 Left=�$��Center=�8��  $��15(�$��5 0 0 0q� P�  �@J�IsMouseOver . . ��� $ ResetNormal�� � y�$ 	Collapsed=��� $ 
ResetHover�� � y�$ Visible=��� 8  $ 	ResetText�� � ���� " ��.���  � �� �� "	 ��.R��� $
 
Horizontal=�
������ .+�� .+��� $ 
MeshNormal��$��Images\MeshNormal.png��$
��None=�$��Center=��� $ 	MeshHover��$��Images\MeshHover.png��$
��None=�$��Center=�$y�	Collapsed=��� $ MeshText��#��z��$
 Left=�$��Center=�8��  $��15(�$��5 0 0 0q� P�  �@J�IsMouseOver . . ��� $ 
MeshNormal�� � y�$ 	Collapsed=��� $ 	MeshHover�� � y�$ Visible=��� 8  $ MeshText�� � ���� " 	�.���  � �� �� "	 	�.R��� $
 
Horizontal=�
������ .+�� $ RadioButtonChecked��.+��� $ CheckedNormal��$#��Images\RadioCheckedNormal.png��$
��None=�$��Center=��� $ CheckedHover��$"��Images\RadioCheckedHover.png��$
��None=�$��Center=�$y�	Collapsed=�� $ RadioButtonUnchecked��$y�	Collapsed=�.+��� $ UncheckedNormal��$%��Images\RadioUncheckedNormal.png��$
��None=�$��Center=��� $ UncheckedHover��$$��Images\RadioUncheckedHover.png��$
��None=�$��Center=�$y�	Collapsed=��� $ RadioButtonText��#��z��$
 Left=�$��Center=�8��  $��15(�$��5 0 0 0q� P�  �@d�	IsChecked$ falseY�. ��� $ RadioButtonChecked�� � y�$ 	Collapsed=��� $ RadioButtonUnchecked�� � y�$ Visible=�P�  �@J�IsMouseOver . . ��� $ CheckedNormal�� � y�$ 	Collapsed=��� $ UncheckedNormal�� � y�$ 	Collapsed=��� $ CheckedHover�� � y�$ Visible=��� $ UncheckedHover�� � y�$ Visible=��� 8  $ RadioButtonText�� � ���� $ 	#ff6e6e6e��.��� -   $��
layoutGrid��$��	10 0 10 0q�.+��� $
��Scan��$
��Left=�$��40��$��	10,10,0,0q�$	��Top=�$	��160��$��15(�$��Center=�$��Center=�  Kinect_Purple_Brush#���  
�������(� $��1��" (� Stretch$" Uniform=�$��Center=�.���� -   $��Image��$	��640��$	��480���� -   # ��Name$# Button_Done��$
��Done��$
��Left=�$��
90,686,0,0q�$	��Top=�$��75��$ J� RenderTransformOrigin$$ 2.244,1.114&��� -   $# Button_Restart��$��Restart��$
��Left=�$��653,688,0,0q�$	��Top=�$��75��$$ -0.727,0.332&��� -   $��	statusBar��$��Stretch=�$��Bottom=�
�������#��[
 $��27��$��0,0,-0.4,0.4q�.@��� $��0 0 0 10q�$��62���� -   $ statusBarText���� $3�-Press 'Start' to begin collecting depth data.���� -   $# Button_Close��$��Close��$
��Left=�$��733,688,0,0q�$	��Top=�$��75���� -	   $# Button_Start��$��Start��$
��Left=�$��
10,686,0,0q�$	��Top=�$��75��