   M S B A M L   `   `   `  ����I  ETuPesoEspacial, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TuPesoEspacialTuPesoEspacial  5      %    TuPesoEspacial.PlanetDetailPage   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:TuPesoEspacial     5        N� Title$  PlanetDetailPage��5	       � Triggers 5      :� 5   
    :� RoutedEvent$ Page.Loaded��6   .[�5      �� .��5      �� .��5      W�  �� TargetProperty$ Opacity�6&    W� From 0.06J   	 W� To 1.06U    g� Duration$ 0:0:0.5D�6^   5      5      5       � 	Resources 5         NavButtonStyle �� 
TargetType	 �� Property
 �� Value �� 
TargetType �� Triggers P� Property P� Value��%U  &	        �� 5   
   " ��6'   .�5      �� 	 � ��

 ���� 6+   �� 5      	 � ��

 �����6+   �� 5      	 � ��$
 60(�6)   �� 5      	 � ��$
 Segoe MDL2 Assets)�6+   �� 5      	 � ��$
 0q�60   �� 5      	 �@�Cursor$

 Hand��6'   �� 5       	 � ��
 5!      �� 5"      " ��6&   .R�5#      �� 
������ ._�5$      �� #��z��6(   #��z��6I   $��Center=�6s   $��Center=�6�   5%       5&      P� 5'       �@J�IsMouseOver$
 True��6=   . �5(   "   �� 	 � ��
 �#FED0006?   5)      5+      5-      5.      5/      .��51      �� ��54   
   �� 55       �� ImageSource$  /Images/Fondos/FONDO 4.png��6    j� Stretch$ UniformToFill=�6B   .+�5:   
   ��  �� Left$	 100��6   
 �� Top$	 150��6'   .+�5<      �� $	��450��6   $	��250��6!    �� CornerRadius$ 20��6.   ���#2C3E50$��0,0,0,30q�6U   ._�5=      �  � ColumnDefinitions 5>      �� 5?      $
��Auto �6+   �� 5@      $��* �6+   .+�5C      �� -   5         ��Name$ UserPhotoBorder��5C      $	��180��66   $	��180��6B   $ 15��6O   $��30,0,0,0q�6a   5E      �� 5G      $��1��6!   $��Center=�61   $��20,0,0,0q�6L   .+�5H      �� $��Fonts/#Funky Smile)�6>   $��40(�6^   
�������$��0,0,0,20q�6   ��6$   �� *
UserName+6   �� 5I      $��Tu Peso:��6$   $��Fonts/#Funky Smile)�64   $��24(�6T   ���#FED0006b   �� 5J      $��Fonts/#Funky Smile)�6F   $��36(�6f   
���������6$   �� *CalculatedWeight+6t   5K      5L      5M      �� 5P      $	��450��6   $	��400��6!   $ 20��6.   ���#2C3E50._�5Q      �� $��30q�6   .+�5R      �� $��Fonts/#Funky Smile)�6E   $��48(�6e   ���#FED000$��0,0,0,20q�6�   ��6    �� *SelectedPlanet.Name+6�   �� 5S       �� TextAlignment$ Justify=�6L   $
��Wrap=�6d   $��Franklin Gothic Demi)�6x   $��18(�6�   
���������6    �� *SelectedPlanet.Description+6�   5T      5U      5V      �� 5Y   
   $
 1100��6   $	 180��6(   $��Center=�69   .+�5[      �� $	��500��6@   $	��500��6L   ��6   �� *SelectedPlanet.ImagePath+6L   �� 5^      $ Center=�5_      $��Fonts/#Funky Smile)�5`      $��72(�5a      
�������$��0,20,0,0q�5c      ��5^      �� *SelectedPlanet.Name+5c      5d      �� 5h   
   -   5         ��Name$ PreviousButton��5h      $	����6F   $	 850��6Y   $	 400��6k   #��[  6|   �� 5i   
   -   5        $ 
NextButton��5i      $	����6>    �� Right$	 100��6Q   $	 400��6d   #��[  6u   �� 5l   
   -   5        $ 
BackButton��5l      $��REGRESAR��5m      $��48(�5o      $��Fonts/#Funky Smile)�5p       � Cursor$
 Hand��5q      $	��524��5r      $	��100��5s      $	 900��5t      $	 698��5u      ��5v      �� 5w      " ��6   .�5x      �� 	 � ��
 �#FED00063   �� 5y      	 � ��
 �#2C3E5063   �� 5z      	 � ��
 5{      �� 5|      " ��6.   .R�5}   "   �� #��z��6)   $ 20��6S   ._�5~   &   �� $��Center=�67   $��Center=�6T   5   #   5�      5�       �� Triggers 5�      P� 5�       �@J�IsMouseOver$
 True��69   . �5�      �� 	 � ��
 �#F39C126;   5�      5�      5�      5�      5�      