   M S B A M L   `   `   `  ����K  GProductsTestTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ProductsTestTaskProductsTestTask  5   	   !    ProductsTestTask.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ProductsTestTask     5   	     � Title$  Product Table��5   	   $	��644��6   $
��1230��6,    � 
ResizeMode$ NoResize=�5	   	    � WindowStartupLocation$ CenterScreen=�5
   	   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	DataTable��5      $��Center=�6&   $	��504��6C   $	��Top=�6P   $
��1200��6h      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 100 5         
IsReadOnly$
 True��5         SelectionMode$ Single=�6%      CanUserSortColumns$ False��5         CanUserReorderColumns$ False��5      $��0,10,0,0q�61   �� 5   
   -   5        $��add product��5      $
��Left=�6'   $��30��6B   $��
15,565,0,0q�6N   $	��Top=�6b   $	��100��6z   6�   �� 5   
   -   5        $��delete product��5      $
��Left=�6*   $��29��6E   $��235,566,0,0q�6Q   $	��Top=�6f   $	��100��6~   6�   �� 5   
   -   5        $��update product��5      $
��Left=�6*   $��29��6E   $��125,566,0,0q�6Q   $	��Top=�6f   $	��100��6~   6�   �� 5   
   -   5        $��generate products��5      $
��Left=�6-   $��29��6H   $��345,566,0,0q�6T   $	��Top=�6i   $	��120��6�   6�   �� 5   
   -   5        $��filter products��5      $
��Left=�6+   $��29��6F   $��1077,566,0,0q�6R   $	��Top=�6h   $	��120��6�   6�   �� 5   
   -   5        $��search_text��5      $
��Left=�5      $��516,527,0,0q�6-   	 �� TextWrapping$
	 Wrap=�6B   $�� ��6V   $	��Top=�6^   $	��537��6v   $��29��6�   
 �� TextAlignment$
 Center=�5      $��16(�6)   5      �� 5   
   -   5        $��
search_box��5      $
��Left=�5      $��1078,529,0,0q�6.   $	��Top=�6D   $	��119��6\   $��26��6h   5      �� 5    
   -	   5        $��rows_count_label��5    n   $��Rows count: ��6   $
��Left=�6'   $��
15,519,0,0q�6B   $	��Top=�6V   6n   5"      5#      