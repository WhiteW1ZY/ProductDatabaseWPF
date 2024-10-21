using ProductsTestTask.Forms;
using ProductsTestTask.Services;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static ProductsTestTask.Services.ProductService;

namespace ProductsTestTask
{
    public partial class MainWindow : Window
    {
        private readonly ProductService _productService;

        public MainWindow()
        {
            InitializeComponent();
            _productService = new ProductService();

            search_box.ItemsSource = Enum.GetValues(typeof(ProductService.ProductFilterEnum));
            search_box.SelectedIndex = 0;

            FillDataTable();
        }

        private void FillDataTable() 
        {
            ProductService.ProductFilterEnum enumValue;

            try
            {
                enumValue = (ProductService.ProductFilterEnum)Enum.Parse(typeof(ProductService.ProductFilterEnum), search_box.Text);
            }
            catch (Exception ex) { enumValue = (ProductFilterEnum)Enum.GetValues(typeof(ProductFilterEnum)).GetValue(0); }

            var searchText = search_text.Text;

            var products = _productService.GetProducts(enumValue, searchText);

            DataTable.ItemsSource = products;
            rows_count_label.Content = $"Rows count: {products.Count}";
        }

        private void AddProductButtonClick(object sender, RoutedEventArgs e)
        {
            var addProductForm = new AddProductForm();
            this.Close();
            addProductForm.Show();
        }

        private void DeleteProductButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = DataTable.SelectedCells[0].Item;
                var cellContent = DataTable.Columns[0].GetCellContent(DataTable.SelectedCells[0].Item) as TextBlock;
                _productService.DeleteProduct(Guid.Parse(cellContent.Text));
                FillDataTable();
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Something went wrong. You may not have highlighted the cell.");
            }
        }

        private void UpdateProductButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItem = DataTable.SelectedCells[0].Item;
                var cellContent = DataTable.Columns[0].GetCellContent(DataTable.SelectedCells[0].Item) as TextBlock;

                var updateProductForm = new UpdateProductForm(Guid.Parse(cellContent.Text));

                this.Close();
                updateProductForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong. You may not have highlighted the cell.");
            }
        }

        private void GenerateProductsButtonClick(object sender, RoutedEventArgs e)
        {
            _productService.GenerateALotOfLines();
            FillDataTable();
        }

        private void FilterProductsButtonClick(object sender, RoutedEventArgs e)
        {
            FillDataTable();
        }
        private void MyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                FillDataTable();
            }
        }
    }
}