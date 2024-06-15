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
        public bool stopForLoop = false;
        public MainWindow()
        {
            InitializeComponent();
            lvProducts.ItemsSource = Data.AmazonPoducts;
        }

        private void btnAddNewProduct_Click(object sender, RoutedEventArgs e)
        { 
            //ProductEntry productEntry = new ProductEntry();
            //productEntry.Show();
            bool producutEntryWindowIsOpen = Application.Current.Windows.OfType<ProductEntry>().FirstOrDefault() == null;
            //Open up an new window for a button click you have to create a new instance of the window then do .Show() on it
            
            if (producutEntryWindowIsOpen)
            {
                new ProductEntry().Show();
            }
            else
            {
                MessageBox.Show("Prudcut Entry window is already open");
            }
            
        }

        private void lvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Product selectedProduct = lvProducts.SelectedItem as Product;
            //refrersh list view incase an item has been edited
            lvProducts.Items.Refresh();
            if (selectedProduct != null)
            {
                rtbProduct.Document = selectedProduct.FormattedProdcutPost();
                imgProduct.Source = selectedProduct.Image;

            }

            
        }

        private void btnOpenEdit_Click(object sender, RoutedEventArgs e)
        {
            bool editProductWindowIsOpen = Application.Current.Windows.OfType<EditProduct>().FirstOrDefault() == null;

            if (editProductWindowIsOpen)
            {
                new EditProduct().Show();
                
            }
            else
            {
                MessageBox.Show("Edit Product Window is already open");
            }
        }

        private async void btnSlideShow_Click(object sender, RoutedEventArgs e)
        {
            cnvSlideShow.Visibility = Visibility.Visible;
            for (int i = 0; i < Data.AmazonPoducts.Count && !stopForLoop; i++)
            {
                ImgSlideShow.Source = Data.AmazonPoducts[i].Image;
                await Task.Delay(5000);
            }
            cnvSlideShow.Visibility = Visibility.Hidden;
        }

        private async void btnStopSlide_Click(object sender, RoutedEventArgs e)
        {
            stopForLoop = true;
            
            cnvSlideShow.Visibility= Visibility.Hidden;
        }
    }
}


//Rich Text Box ( Advanced )
//List View ( Plus Click Event )
//Image
//Button


