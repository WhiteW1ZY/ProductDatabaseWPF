using ProductsTestTask.Models.Dto;
using ProductsTestTask.Services;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace ProductsTestTask.Forms
{
    public partial class UpdateProductForm : Window
    {
        private readonly ProductService _productService;
        private Guid productId;

        public UpdateProductForm(Guid ProductId)
        {
            InitializeComponent();

            _productService = new ProductService();

            productId = ProductId;

            FillForm();
        }

        private void FillForm() 
        {
            var product = _productService.GetProductById(productId);

            if (product is null)
            {
                throw new ArgumentException("Product is not exist");
            }

            code_box.Text = product.Code.ToString();
            name_box.Text = product.Name;
            barcode_box.Text = product.BarCode;
            quantity_box.Text = product.Quantity.ToString();
            model_box.Text = product.Model;
            sort_box.Text = product.Sort;
            color_box.Text = product.Color.ToString();
            size_box.Text = product.Size.ToString();
            wigth_box.Text = product.Wight.ToString();
            price_box.Text = product.Price.Price.ToString();
        }


        private void DecimalTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextDecimal(e.Text);
        }

        private bool IsTextDecimal(string text)
        {
            return Regex.IsMatch(text, @"^[0-9]*(\.[0-9]*)?$");
        }

        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextNumeric(e.Text);
        }

        private bool IsTextNumeric(string text)
        {
            return Regex.IsMatch(text, @"^[0-9]+$");
        }

        private void OpenMain()
        {
            var main = new MainWindow();
            this.Close();
            main.Show();
        }

        private void backward_button_Click(object sender, RoutedEventArgs e)
        {
            OpenMain();
        }

        private void confirm_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int code = int.Parse(code_box.Text);
                string name = name_box.Text;
                string barcode = barcode_box.Text;
                decimal quantity = decimal.Parse(quantity_box.Text);
                string model = model_box.Text;
                string sort = sort_box.Text;
                string color = color_box.Text;
                string size = size_box.Text;
                string wight = wigth_box.Text;
                decimal price = decimal.Parse(price_box.Text);

                _productService.UpdateProduct(productId, new ProductRaw
                {
                    Code = code,
                    Name = name,
                    BarCode = barcode,
                    Quantity = quantity,
                    Model = model,
                    Sort = sort,
                    Color = color,
                    Size = size,
                    Wight = wight,
                    Price = price
                });

                OpenMain();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong. Please, verify correct entry");
            }
        }
    }
}
