   M S B A M L   `   `   `  ���� P  LRename File Or Folder, Version=1.0.0.1, Culture=neutral, PublicKeyToken=null;"clr-namespace:Rename_File_Or_FoderRename_File_Or_Foder  %    Rename_File_Or_Foder.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     4local"clr-namespace:Rename_File_Or_Foder     -     � Title$  Rename File Or Folder��$	��500��$	��800�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.���  � ColumnDefinitions �� $
��199* �.+��� -   $��listData��$��10,10,10,153q� �� View �� .P��� .���� -    ��Name$ checkAll��$��10,0,0,0q� d� 	IsChecked$
 TrueY� �� CellTemplate �� .R��� $��10,0,0,0q� ��  �� Path$ Select��� $
��Path��	 �� Width$		 190��
 �� DisplayMemberBinding
 �� *Path+�� $��Date Modified��$		 130��
 �� *DateModified+�� $��	File Name��$		 150��
 �� *
FileName+�� $��New File Name��$		 150��
 �� *NewFileName+�� $��Status��$		 100��
 �� *Status+]� $
��Left=�$	��143����.  $��	10,0,0,10q�$��Bottom=�$	��774�� J� RenderTransformOrigin$ 0.544,0.508&�$��2��.+�]� $��78����.  $	��Top=�$	��368��$��10,10,10,10q�.+��� $"��Chọn Mục Để Thao Tác��$	��131��$	��Top=�$	��363��$��	0,0,0,-53q�.��� $��0,0,-2,3q� �� $	��11* ��� $
��113* �.+��� $
��Left=�$��	10,10,0,0q�$��70��$��Chọn Mục��$	��Top=�$
��Bold"�$��2���� -    ��Name$ txtFoderInput��$
��Left=�$��23��$��52.466,9,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��183��$��1���� -    ��Name$ btnLoadFoder��$��Lấy Thư Mục��$
��Left=�$��
240,10,0,0q�$	��Top=�$��81�����	#FF5DAA4B$
��Bold"�$��1�� J� OpacityMask ��  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Black�� � Offset$ 0Q�� $ 	#FFD63434��$ 1Q��� $
��Left=�$��	10,37,0,0q�$��70��$��Đuôi File��$	��Top=�$
��Bold"�$��2���� -   $ 
txtFillter��$��*.txt|*.mp4|*��$
��Left=�$��23��$��	52,37,0,0q�$
 Wrap=�$	��Top=�$	��183��$��1��{�.  �� -   $ chkFoder��$��
Thư Mục��$
��Left=�$��	52,71,0,0q�$	��Top=�$��1���� -   $ chkFile��$
��File��$
��Left=�$��
138,71,0,0q�$	��Top=�$��1��$
 TrueY��� -	   $ 
chkFillTer��$��Theo Đuôi��$
��Left=�$��
240,41,0,0q�$	��Top=�$��1��$ FalseY��� -
   $ btnLoaDanhSach��$!��Lấy Danh Sách Mục/File��$
��Left=�$��230,91,0,-4q�$	��Top=�$��85�����	#FFCBCB6B$
��Bold"�$��1�� �� $ 0.5,1&�$ 0.5,0&�.��� $ Black��$ 0Q�� $ 	#FFD63434��$ 1Q��� -    ��Name$ 
lblSoLuong��$
��Left=�$��
197,70,0,0q�$��
Có:0 File��$	��Top=�$��1��]� $	��133����.  $��Bottom=�$	��369��$
��10,0q�.+��� $��Tên Sau Khi Đổi��$	��133��$	��Top=�$	��362��.��� .+��� $
��Left=�$��10,5,0,0q�$��70��$��Tên Bắt Đầu��$	��Top=��� -   $ txtNameBegin��$��notepr-��$
��Left=�$��23��$��85,4,0,0q�$
 Wrap=�$	��Top=�$	��118��{�. �� $
��Left=�$��	223,8,0,0q�$��61��$��Số Bắt Đầu��$	��Top=��� -   $ 	txtNumber��$
��Left=�$��1��$��23��$��	284,5,0,0q�$
 Wrap=�$	��Top=�$��56���� -   $ btnExportNow��$��Xuất Dữ Liệu��$
��Left=�$��	10,71,0,0q�$	��Top=�$��78���� -   $ 
btnPreview��$��Xem Trước��$
��Left=�$��	93,71,0,0q�$	��Top=�$��65���� -   $ 
btnInExcel��$ ��Nhập File Định Dạng��$
��Left=�$��
163,71,0,0q�$	��Top=�$	��116���� -   $ btnChangerName��$��Đổi Tên��$
��Left=�$��
284,71,0,0q�$	��Top=�$��60�����	#FF4ED648�� $
��Left=�$��100,98,0,-1q�$
��Wrap=�$��
Facebook :��$	��Top=�$��50��$��10(�$
��Bold"��� $��
155,96,4,0q��� -   $&�� https://www.facebook.com/notepr/?�.�" https://www.facebook.com/notepr/�� -   $ chkTenBatDau��$��Có tên bắt đầu��$
��Left=�$��	85,32,0,0q�$	��Top=�$
 TrueY�$��10(��� -   $ chkBatDauNgay��$+��%Tên Bắt Đầu -> Ngày Tạo File��$
��Left=�$��
190,32,0,0q�$	��Top=�$
 TrueY�$��10(��� -    ��Name$ Splash��$��4�� J� Opacity$ .2Q�$y�	Collapsed=�
���   �