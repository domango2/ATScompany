   M S B A M L   `   `   `  ����E  AATScompany, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:ATScompanySpaceATScompanySpace  5   	       ATScompanySpace.UserPanel   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:ATScompanySpace     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  	UsepPanel��5	   	   $	��540��6   $	��960��6(    � Icon$ /iconATS.ico��64   $
��1920��5
   	   $
��1080��6   $	��960��6*   $	��540��69   .��5      � $
��1920��6   $
��1080��6   $	��960��6,   $	��540��6;    � ColumnDefinitions 5   
   �� 5      $��* �6   5      �� 5      $��3* �6   6,    � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   �� 5      $��1* �6   6*   ��5   
   �� 5       �� ImageSource$ 	/back.png��6   .+�5   	   �� -   5         ��Name$ 	myAccount��5      $��0��6#   $��0��63   $��Мои данные��6@   $��Center=�6U   $��0,0,0,0q�6r   $��Center=�6�   $	��190��6�   6�   �� 5    
   -   5        $ 
myInvoices��5       $��0��6%   $��1��65   $)��#Выставленные счета��6B   $��Center=�6_   $��0,0,0,0q�6|   $��Center=�6�   $	��190��6�   6�   �� 5!   
   -   5        $ payInvoices��5!      $��0��6&   $��2��66   $!��Оплатить счета��6C   $��Center=�6\   $��0,0,0,0q�6y   $��Center=�6�   $	��190��6�   6�   �� 5"   
   -   5        $ makeDeposit��5"      $��0��6&   $��3��66   $!��Пополнить счет��6C   $��Center=�6\   $��0,0,0,0q�6y   $��Center=�6�   $	��190��6�   6�   �� 5#   
   -   5        $ makeCall��5#      $��0��6#   $��4��63   $#��Добавить звонок��6@   $��Center=�6Z   $��0,0,0,0q�6w   $��Center=�6�   $	��190��6�   6�   �� 5$   
   -   5        $ logout��5$      $��0��6!   $��5��61   $&�� Выйти из аккаунта��6>   $��Center=�6u   $��Center=�6�   $	��190��6�   $��0,0,0,0q�6�   �� 5'   
   $��1��6   $��0��6"   $��6��6/   
�������$��Stretch=�6S   $��Stretch=�6o    �� Padding$ 30q�6�   $��32,32,32,42q�6�    �� CornerRadius$ 20��6�    J� Effect 5(      3  -System.Windows.Media.Effects.DropShadowEffect  5)      	   
BlurRadius$	 30Q�6#   
   Color$
 	LightGray��63      ShadowDepth$ 0Q�6E   6W   ._�5+      �� $
��Auto=�6   .��5,      �� -   5         ��Name$ displayText��5,   S    !  MaterialDesignButtonTextBlock#��[  6   $��20,50,20,20q�6h   $
��Wrap=�6}   $�� ��6�   
���   �$��16(�6�   
�������5-      5.      5/      51      53      