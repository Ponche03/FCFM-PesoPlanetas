   M S B A M L   `   `   `  ����I  ETuPesoEspacial, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TuPesoEspacialTuPesoEspacial  5      "    TuPesoEspacial.NameInputPage   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:TuPesoEspacial     5        N� Title$  NameInputPage��5	       � Triggers 5      :� 5   
    :� RoutedEvent$ Page.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�5       W� From 0.05      	 W� To 1.05       g� Duration$ 0:0:1D�5      5      5      5      .��5      �� ��5   
   �� 5       �� ImageSource$  /Images/Fondos/FONDO 3.png��6    j� Stretch$ UniformToFill=�6B   .+�5"   
   �� $
��1920��6   
	 �� Top$		 320��6"   $��Center=�63   $��Center=�6N   
 �� TextAlignment$
 Center=�6k   .+�5%      �� $��90(�6   $��0,0,0,30q�6&   $��Fonts/#Funky Smile)�68   ��5&      �� 5'       �� Color$ White��6&   �� 5)      $�
Escribe tu��6    �� 5*      $�nombre��6   $
��Bold"�6$   ���#FED00066   5,      �� 5/       �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�51      �� -   5         ��Name$ NameTextBox��51      $	��600��6/   $��48(�6;   $��Fonts/#Funky Smile)�6I   
�������
������ $��0,0,0,4q�6�    �� 
CaretBrush
 ����� �� TextAlignment$ Center=�6�   .��6�   ��52      �� 53      $ #FED000��6*   .��54   +   55      56      �� 59      -   5         ��Name$ 
NextButton��59      $��	SIGUIENTE��5:      $��48(�5<      $��Fonts/#Funky Smile)�5=       � Cursor$
 Hand��5>      $��Center=�5?      $	��400��5@      $	��100��5A      $��0,80,0,0q�5B      ��5C      �� 5D       �� 
TargetType" ��6   .�5E      ��  �� Property � �� �� Value �#FED00067   �� 5F       � �� �#2C3E5067   �� 5G       � �� 5H      �� 5I   "    �� 
TargetType" ��62   .R�5J   &   �� #��z��6-    �� CornerRadius$ 20��6W   ._�5K   *   �� $��Center=�6;   $��Center=�6X   5L   '   5M   #   5O       �� Triggers 5P      P� 5Q       P� Property �@J�IsMouseOver P� Value$
 True��6=   . �5R   "   ��  � �� �#F39C126?   5S      5U      5W      �� 5Z      -   5         ��Name$ ErrorTextBlock��5Z      ���#FF5252$��20(�6E   $��0,20,0,0q�6S   $
��Bold"�6e   $��Arial)�6w   5[      �� 5]   
   $$��/Images/Astronautas/POSE_2.png��6   $	��320��5^      $	��320��5_       �� Left$	 101��5`      $		 163��5a      $
��Left=�6   $	��Top=�64   5b      5c      