   M S B A M L   `   `   `  ����H  DTazeDirektWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:TazeDirektWpfTazeDirektWpf  5   	       TazeDirektWpf.UrunListele   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:TazeDirektWpf     5   	   -   5          � Title$  UrunDuzenle��5   	   $	��650��6   $	��600��6*    � 
ResizeMode$ NoResize=�66   .��5	      � $��
0,0,0,-208q�6   .+�5
   
   �� $	��Top=�6   
�������$��	0,1,0,776q�6=   .+�5      � $��98��6   .+�5      �� $��50��6   $��59,0,330,50q�6$   $��images\logoTD.PNG��69   �� 5      $��50��6   $��
3,0,413,50q�6$   $��images\nyo-logo.jpg��68    J� RenderTransformOrigin$ 	-8.6,0.35&�6U   �� 5      $
��Left=�6   $	��110��63   $��1083,0,0,-10q�6@   $	��Top=�6V   $	��109��6n   $��images\sepet.PNG��6z   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgUrunList��5   *   $
��Left=�6>   $	��397��6Y   $��
45,134,0,0q�6f   $	��Top=�6z   $	��497��6�      AutoGenerateColumns .     GridLinesVisibility$
 None=�5      
�������   AreRowDetailsFrozen .    FrozenColumnCount$ 2��6`      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      -   5        
chkCol��,  &System.Windows.Controls.DataGridColumn	   Header$
	 Seç��5   9   
   CellTemplate
 5      �� 5      .R�5      �� -   5         d� 	IsChecked 5   '   �� *
CheckAll+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5      5       0  *System.Windows.Controls.DataGridTextColumn  5!         
IsReadOnly . $	 Kategori��6]      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6o   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$ Kategori.Adi�6o     5"       . $	 Ürün Adı��6T   $	 100 6f    6%   �� $	 Adi�6f     5#       . $	 
Açıklama��6Y   $	 100 6k    6%   �� $ Aciklama�6k     5$       . $	 
Tedarikçi��6^   $	 100 6q    6%   �� $ Tedarikci.Adi�6q   5+      �� 5,   
   -   5         ��Name$ 	lblDelBtn��5,      $	��Sil��6#   $
��Left=�61   $��
45,103,0,0q�6L   $	��Top=�6`   ���	#FFEC1C1C
�������6�   5.      5/      