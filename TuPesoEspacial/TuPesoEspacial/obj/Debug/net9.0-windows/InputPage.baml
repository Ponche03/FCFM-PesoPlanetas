   M S B A M L   `   `   `  ����I  ETuPesoEspacial, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TuPesoEspacialTuPesoEspacial  5          TuPesoEspacial.InputPage   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:TuPesoEspacial     5        N� Title$  	InputPage��5	       � Triggers 5      :� 5   
    :� RoutedEvent$ Page.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�5       W� From 0.05      	 W� To 1.05       g� Duration$ 0:0:1D�5      5      5      5      .��5      �� ��5   
   �� 5       �� ImageSource$  /Images/Fondos/FONDO 2.png��6    j� Stretch$ UniformToFill=�6B   .+�5"   
   �� $
��1920��6   
	 �� Top$		 320��6"   $��Center=�63   $��Center=�6N   
 �� TextAlignment$
 Center=�6k   .+�5%      �� $��90(�6   $��0,0,0,30q�6&   $��Fonts/#Funky Smile)�68   
��������� 6l   $�Escribe tu peso en��6p   �� 6�   $� ��6�   �� 6�   ���	#FFFED000$�	La Tierra��6�   �� 6�   $� ��6�   6�   �� 5(       �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5*      �� -   5         ��Name$ WeightTextBox��5*      $	��300��61   $��48(�6=   $��Fonts/#Funky Smile)�6K   
�������
������ $��0,0,0,4q�6�    �� 
CaretBrush
 �����.��6�   ��5+      �� 5,       �� Color$ #FED000��6*   .��5-   +   5.      �� 5/      $��KG��6   $��48(�6&   $��Fonts/#Funky Smile)�64   
�������$��Bottom=�6g   $��20,0,0,5q�6�   50      �� 53      -   5         ��Name$ CalculateButton��53      $��	SIGUIENTE��54      $��48(�56      $��Fonts/#Funky Smile)�57       � Cursor$
 Hand��58      $��Center=�59      $	��400��5:      $	��100��5;      $��0,80,0,0q�5<      ��5=      �� 5>       �� 
TargetType" ��6   .�5?      ��  �� Property � �� �� Value �#FED00067   �� 5@       � �� �#2C3E5067   �� 5A       � �� 5B      �� 5C   "    �� 
TargetType" ��62   .R�5D   &   �� #��z��6-    �� CornerRadius$ 20��6W   ._�5E   *   �� $��Center=�6;   $��Center=�6X   5F   '   5G   #   5I       �� Triggers 5J      P� 5K       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �5L   "   ��  � �� �#F39C126?   5M      5O      5Q      �� 5T      -   5         ��Name$ ErrorTextBlock��5T      ���#FF5252$��20(�6E   $��0,20,0,0q�6S   $
��Bold"�6e   $��Arial)�6w   5U      �� 5W   
   $$��/Images/Astronautas/POSE_3.png��6   $	��320��5X      $	��320��5Y       �� Left$
 1408��5Z      $		 615��5[      $
��Left=�6   $	��Top=�69   5]      5^      