   M S B A M L   `   `   `  ����I  ETuPesoEspacial, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TuPesoEspacialTuPesoEspacial  5          TuPesoEspacial.InputPage   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:TuPesoEspacial     5        N� Title$  	InputPage��5	       � Triggers 5      :� 5   
    :� RoutedEvent$ Page.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�5       W� From 0.05      	 W� To 1.05       g� Duration$ 0:0:1D�5      5      5      5      .��5      (�  (� Stretch$ UniformToFill=�6   .��5   
   � $
��1920��6   $
��1080��6   ��5      �� 5       �� ImageSource$  /Images/Fondos/FONDO 2.png��6   	 j� Stretch$	 UniformToFill=�6F   .+�5#      �� $$��/Images/Astronautas/POSE_3.png��6   $	��320��5$      $	��320��5%      $��Right=�5&      $��Bottom=�5'      $��100,0,100,80q�5(      �� 5+      $��Center=�6   $��Center=�5,      
 �� TextAlignment$
 Center=�5-      .+�50      �� $��90(�6   $��0,0,0,30q�6*   $��Fonts/#Funky Smile)�6<   
��������� 51      $�Escribe tu peso en��6    �� 52      ���	#FFFED000$�
 La Tierra��61   53      �� 56       �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�57      �� -   5         ��Name$ WeightTextBox��57      $	��300��58      $��48(�59      $��Fonts/#Funky Smile)�5:      
�������
������ $��0,0,0,4q�5=       �� 
CaretBrush
 ��������#FED0005@      �� 5B      $��KG��6    $��48(�5C       $��Fonts/#Funky Smile)�5D       
�������$��Bottom=�5F       $��20,0,0,5q�5G       5H      �� 5K      -   5         ��Name$ CalculateButton��5K      $��	SIGUIENTE��5L      $��48(�5N      $��Fonts/#Funky Smile)�5O       � Cursor$
 Hand��5P      $��Center=�5Q      $	��400��5R      $	��100��5S      $��0,80,0,0q�5T      ��5U      �� 5V       �� 
TargetType" ��6    .�5W      ��  �� Property � �� �� Value �#FED0006;   �� 5X       � �� �#2C3E506;   �� 5Y       � �� 5Z   "   �� 5[   &    �� 
TargetType" ��66   .R�5\   *   �� #��z��61    �� CornerRadius$ 20��6[   ._�5]   .   �� $��Center=�6?   $��Center=�6\   5^   +   5_   '   5a       �� Triggers 5b      P� 5c   "    P� Property �@J�IsMouseOver P� Value$
 True��6A   . �5d   &   ��  � �� �#F39C126C   5e   #   5g      5i      �� 5l      -   5         ��Name$ ErrorTextBlock��5l      ���#FF5252$��20(�5n      $��0,20,0,0q�5o      $
��Bold"�5p      $��Arial)�5q      5r      5s      5t      5u      