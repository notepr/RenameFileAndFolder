   M S B A M L   `   `   `  ����O  KRename File Or Foder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:Rename_File_Or_FoderRename_File_Or_Foder  5   	   "    Rename_File_Or_Foder.Custome   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:Rename_File_Or_Foder     5   	     � Title$.  (Chọn đường dẫn để xuất file��5   	    � SizeToContent$ WidthAndHeight=�6-    � WindowStartupLocation$ CenterScreen=�6L    � 
ResizeMode$ NoResize=�5	   	   .��5
      � $��15q�6   $	��369��6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��/img/question-icon.png��6   $��32��60   $��32��6;   $��2��6G   $
��20,0q�6X   �� 5   
   -   5        $��lblQuestion��5      $��1��6#   .��63   Đường Dẫn6>   �� 5   
   -   5        $��	txtAnswer��5      $��1��6#   $��1��63   $	��200��6@   $��0,0,97,0q�6O   6c   �� 5   
   -   5         ��Name$ btnLoadPath��5      $
��Bold"�6&   $��	205,0,0,0q�68   $��1��6K   $��1��6X   $
��Left=�6�   $��82��6�   .��6�   Lấy Thư Mục6�   � 5   
   $��2��6   $��2��6!   $��Right=�65   $��0,15,0,0q�6Q   .+�5      �� -   5        $��btnDialogOk��5   &    �� 	IsDefault . $��60��69   $��0,0,10,0q�6G   .��6s   Ok6w   �� 5       �� IsCancel . $��60��6%   .��63   Cancel6;   5      5      5       