   M S B A M L   `   `   `  ����I  ETuPesoEspacial, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TuPesoEspacialTuPesoEspacial  5      "    TuPesoEspacial.NameInputPage   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:TuPesoEspacial     5        N� Title$  NameInputPage��5	       � Triggers 5      :� 5   
    :� RoutedEvent$ Page.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�5       W� From 0.05      	 W� To 1.05       g� Duration$ 0:0:1D�5      5      5      5      .��5      (�  (� Stretch$ UniformToFill=�6   .��5   
   � $
��1920��6   $
��1080��6   ��5      �� 5       �� ImageSource$  /Images/Fondos/FONDO 3.png��6   	 j� Stretch$	 UniformToFill=�6F   .+�5#      �� $$��/Images/Astronautas/POSE_2.png��6   $	��320��5$      $	��320��5%      $
��Left=�5&      $	��Top=�5'      $��100,160,0,0q�5(      �� 5+      $��Center=�6   $��Center=�64   
 �� TextAlignment$
 Center=�6Q   .+�5-      �� $��90(�6   $��0,0,0,30q�6*   $��Fonts/#Funky Smile)�6<   ��5.      �� 5/       �� Color$ White��6*   �� 51      $�
Escribe tu��6    �� 52      $� nombre��6   $
��Bold"�6)   ���#FED0006;   53      �� 56       �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�57      �� -   5         ��Name$ NameTextBox��57      $	��600��58      $��48(�59      $��Fonts/#Funky Smile)�5:      
�������
������ $��0,0,0,4q�5=       �� 
CaretBrush
 ����� �� TextAlignment$ Center=�5?      ���#FED0005A      5B      �� 5E      -   5         ��Name$ 
NextButton��5E      $��	SIGUIENTE��5F      $��48(�5H      $��Fonts/#Funky Smile)�5I       � Cursor$
 Hand��5J      $��Center=�5K      $	��400��5L      $	��100��5M      $��0,80,0,0q�5N      ��5O      �� 5P       �� 
TargetType" ��6    .�5Q      ��  �� Property � �� �� Value �#FED0006;   �� 5R       � �� �#2C3E506;   �� 5S       � �� 5T   "   �� 5U   &    �� 
TargetType" ��66   .R�5V   *   �� #��z��61    �� CornerRadius$ 20��6[   ._�5W   .   �� $��Center=�6?   $��Center=�6\   5X   +   5Y   '   5[       �� Triggers 5\      P� 5]   "    P� Property �@J�IsMouseOver P� Value$
 True��6A   . �5^   &   ��  � �� �#F39C126C   5_   #   5a      5c      �� 5f      -   5         ��Name$ ErrorTextBlock��5f      ���#FF5252$��20(�5h      $��0,20,0,0q�5i      $
��Bold"�5j      $��Arial)�5k      5l      5m      5n      5o      