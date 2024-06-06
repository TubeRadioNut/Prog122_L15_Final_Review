using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Prog122_L15_Final_Review
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lvProducts.ItemsSource = Data.AmazonPoducts;
        }

        private void btnAddNewProduct_Click(object sender, RoutedEventArgs e)
        {
            //Open up an new window for a button click you have to create a new instance of the window then do .Show() on it
            new ProductEntry().Show();
        }

        private void lvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Product selectedProduct = lvProducts.SelectedItem as Product;
            if (selectedProduct != null)
            {
                rtbProduct.Document = selectedProduct.FormattedProdcutPost();
                imgProduct.Source = selectedProduct.Image;

            }

            
        }
    }
}


//Rich Text Box ( Advanced )
//List View ( Plus Click Event )
//Image
//Button


