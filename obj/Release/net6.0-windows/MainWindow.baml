   M S B A M L   `   `   `  ���� E  AATScompany, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ATScompanySpaceATScompanySpace       ATScompanySpace.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:ATScompanySpace     _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$  
ATScompany��$	��540��$	��960�� � Icon$ /iconATS.ico��$
��1920��$
��1080��$	��960��$	��540�� � 	Resources    FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 MyButtonStyle �� 
TargetType	 �� 
TargetType
 ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 R     &	 g     &	 |     &	 �     &	 �     &	 �     &	 �     &	 �     &		 �     &	
     7   7  7  7  7  7  7  7  7  7 	 �� .���  � �� �� .R��� $��2q�$	 1 2R�#��� ��$
 true��$��1���� $ 	#FFDDDDDD���� $ 	#FF707070���� $ 	#FFBEE6FD���� $ 	#FF3C7FB1���� $ 	#FFC4E5F6���� $ 	#FF2C628B���� $ 	#FFF4F4F4���� $ 	#FFADB2B5���� $ 	#FF838383���� " ��.���  �@�FocusVisualStyle8   ��  � ��8  ��  � ��8  ��  � ��# � ����  � ��$ 1q���  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� "	 ��.R��� $
 border��$ 7��#��z��#��z��#��z��$
 true��._��� $ contentPresenter��$|�False��#��z��#��z��$
��True��# z #��z�� P�  �@��IsDefaulted$
 true��. ��� $ border��# � �� � ��P�  �@J�IsMouseOver$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � ��$
 true��. ��� $ border��8   � ���� $ border��8   � ��P�  � {�$ false��. ��� $ border��8   � ���� $ border��8   � ���� $ contentPresenter��8 	  � ��.��� $
��1920��$
��1080��$	��960��$	��540�� � ShowGridLines$ False�� � RowDefinitions �� $��* ��� $
��0.3* ��� $
��0.3* ��� $
��0.3* ��� $
��0.3* ��� $
��1.0* � � ColumnDefinitions �� $��* ��� $
��0.5* ��� $
��1.0* �.+��� $��1��$��
логин��$
��Left=�$��5,0,0,0q�$��1��$��Center=����	#FFD71616$��Arial)�$
��Bold"�$��16(�$��40��$��20��$	��160��$��80��$��Center=��� -    ��Name$ login��$��1��$��Center=�$��1��$��	70,6,10,6q�$	��100��$��20��$	��150��$��20�� J� RenderTransformOrigin$ 0.507,0.373&�$��0,0,0,0q��� $��1��$��пароль��$
��Left=�$��5,0,0,0q�$��2��$��Center=����	#FFD71616$��Arial)�$
��Bold"�$��16(�$��40��$��20��$	��160��$��80��$��Center=�G� -    G�Name$ password��$��Center=�$��1��$��2��$	��100��$��20��$	��150��$��20��$��	70,0,10,0q�$��0,0,0,0q��� -    ��Name$ enter��#��� 
 $��1��$��
войти��$��Center=�$��0,0,0,0q�$��3��$��Center=�$��16(�
���   �
�������$
��Bold"����	#FFAD9D9D �� 	IsDefault$
 True���� -   $ registration��#��� 
 $��1��$��регистрация��$��Center=�$��0,0,0,0q�$��4��$��Center=�$��16(�
����������	#FF3EF60C$
��Bold"����	#FFAD9D9D����  �� ImageSource$ /startWindow.png�� j� Stretch$
 Fill=�