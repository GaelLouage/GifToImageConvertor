   M S B A M L   `   `   `  ����L  HGiftoPngConvertor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:GiftoPngConvertorGiftoPngConvertor  5   	   "    GiftoPngConvertor.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:GiftoPngConvertor     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ GifConvertor��5	   	   $	��550��6   $	��700��6+   .��5
      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��10 �6   .+�5   
   �� $��Output Folder:��6   $��0��6)   $��10q�66   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��10q�6;   .+�5       �� -   5         ��Name$ OutputFolderButton��5       $��Select��61   $��0,0,10,0q�6c   
�����_�
�������$��50��6�    � Cursor$
 Hand��6�   �� 5!      -   5         ��Name$ outputFolderTextBox��5!      $��0,0,10,0q�63   $��Stretch=�6E   $	��310��6c   5"      �� 5$   
   $��File Directory:��6   $��2��6*   $��10q�67   �� 5%   
   $��3��6   $ 
Horizontal=�6"   $��10q�6;   .+�5&      �� -   5        $ FileDirectoryButton��5&      $��Select��62   $��0,0,10,0q�6e   
�����_�
�������$��50��6�   $
 Hand��6�   �� 5'      -   5        $ fileDirectoryTextBox��5'      $��0,0,10,0q�64   $��Stretch=�6F   $	��310��6e   5(      �� 5*   
   -   5         ��Name$ 	imgsBytes��5*   @   $��1��6   $��1��6   $��3��6/   $��10q�6S   ��5+      �� 5,      .R�5-      �� $ 
Horizontal=�6!   5.      ��50      �� 51      .R�52      �� $	��100��69   $	��100��6E   $��5q�6R   ��6   �� *	ImagePath+6R   53      55      �� 58   
   $��8��6   $��10q�6#   $��2��6/   .+�59      �� $��Convert To:��6   $��10q�6*   �� 5:      -   5        	 ��Name$	 convertComboBox��5:      $��10q�61   6=   5;      �� 5=   
   $��9��6   $��10q�6"   $��2��6.   .+�5>      �� $��Pixel size:��6   $��10q�6*   �� 5?      -   5        $	 cmbPixelSize��5?      $��10q�6.   6:   5@      �� 5B   
   -   5        $ ConvertButton��5B      $��Convert��6(   $��10��6:   $��20q�6H   
�����_�
�������$��50��6�   $
 Hand��6�   $��2��6�   5C      5D      