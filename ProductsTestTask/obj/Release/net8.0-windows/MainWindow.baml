   M S B A M L   `   `   `  ���� K  GProductsTestTask, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ProductsTestTaskProductsTestTask  !    ProductsTestTask.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:ProductsTestTask       � Title$  Product Table��$	��644��$
��1230�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=�.��� .+�&   System.Windows.Controls.DataGrid  -     Name$ 	DataTable��$��Center=�$	��504��$	��Top=�$
��1200��   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 100    
IsReadOnly$
 True��   SelectionMode$ Single=�   CanUserSortColumns$ False��   CanUserReorderColumns$ False��$��0,10,0,0q��� -   $��add product��$
��Left=�$��30��$��
15,565,0,0q�$	��Top=�$	��100���� -   $��delete product��$
��Left=�$��29��$��235,566,0,0q�$	��Top=�$	��100���� -   $��update product��$
��Left=�$��29��$��125,566,0,0q�$	��Top=�$	��100���� -   $��generate products��$
��Left=�$��29��$��345,566,0,0q�$	��Top=�$	��120���� -   $��filter products��$
��Left=�$��29��$��1077,566,0,0q�$	��Top=�$	��120���� -   $��search_text��$
��Left=�$��516,527,0,0q�	 �� TextWrapping$
	 Wrap=�$�� ��$	��Top=�$	��537��$��29��
 �� TextAlignment$
 Center=�$��16(��� -   $��
search_box��$
��Left=�$��1078,529,0,0q�$	��Top=�$	��119��$��26���� -	   $��rows_count_label��$��Rows count: ��$
��Left=�$��
15,519,0,0q�$	��Top=�