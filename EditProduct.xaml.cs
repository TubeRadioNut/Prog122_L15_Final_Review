using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Prog122_L15_Final_Review
{
    /// <summary>
    /// Interaction logic for EditProduct.xaml
    /// </summary>
    public partial class EditProduct : Window
    {
        public EditProduct()
        {
            InitializeComponent();//<--Don't delete this and keep at the top of EditProduct()
            lvProducts.ItemsSource = Data.AmazonPoducts;
            PopulateComboBox();
            cmbEditDate.SelectedIndex = cmbEditDate.Items.Count - 1;
        }//end EditProduct

        private void btnOpenMain_Click(object sender, RoutedEventArgs e)
        {
            bool mainWindowIsOpen = Application.Current.MainWindow == null;
            if (mainWindowIsOpen)
            {
                new MainWindow().Show();
            }
            else
            {
                MessageBox.Show("MainWindow is open already");
            }
        }

        private void btnOpenProductEntry_Click(object sender, RoutedEventArgs e)
        {
            bool producutEntryWindowIsOpen = Application.Current.Windows.OfType<ProductEntry>().FirstOrDefault() == null;
            
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
            if (selectedProduct != null)
            {
                txtEditName.Text = selectedProduct.Name;
                txtEditManufacturer.Text = selectedProduct.Manufacturer;
                txtEditPrice.Text = selectedProduct.Price.ToString();
                runEditDescription.Text = selectedProduct.Description;
                txtEditImagePath.Text = selectedProduct.FilePath;
                imgTempImage.Source = selectedProduct.Image;
                
            }
        }

        private void PopulateComboBox()
        {
            for (int i = 1950; i < 2025; i++)
            {
                cmbEditDate.Items.Add(i);
            }
        }

        private void btnEditName_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = lvProducts.SelectedItem as Product;
            if (selectedProduct != null)
            {
                if (txtEditName.Text.Length > 0)
                {
                    selectedProduct.Name = txtEditName.Text;
                    lvProducts.Items.Refresh();
                    
                }
            }
            
        }

        private void btnEditManufacturer_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = lvProducts.SelectedItem as Product;
            if (selectedProduct != null)
            {
                if (txtEditManufacturer.Text.Length > 0)
                {
                    selectedProduct.Manufacturer = txtEditManufacturer.Text;
                    lvProducts.Items.Refresh();

                }
            }
        }

        private void btnEditPrice_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = lvProducts.SelectedItem as Product;
            if (selectedProduct != null)
            {
                if(txtEditPrice.Text.Length > 0)
                {
                    selectedProduct.Price = double.Parse(txtEditPrice.Text);
                    lvProducts.Items.Refresh();
                }
            }
        }

        private void btnEditDate_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = lvProducts.SelectedItem as Product;
            if (selectedProduct != null)
            {
                selectedProduct.DateListed = int.Parse(cmbEditDate.Text);
                lvProducts.Items.Refresh();
            }
        }

        private void btnEditDescription_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = lvProducts.SelectedItem as Product;
            if(selectedProduct != null)
            {
                selectedProduct.Description = runEditDescription.Text;
                lvProducts.Items.Refresh();
            }
        }

        private void btnEditImgPath_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = lvProducts.SelectedItem as Product;
            if (selectedProduct != null)
            {
                //File Picker
                OpenFileDialog filePicker = new OpenFileDialog();
                //display is drop down | Filter by format
                filePicker.Filter = "Image (*.png, *.jpeg, *.jpg, *.webp)|*.png;*.jpeg;*.jpg;*.webp;";

                if (filePicker.ShowDialog() == true)
                {
                    string filePath = filePicker.FileName;
                    txtEditImagePath.Text = filePath;


                    BitmapImage newImage = Product.GenerateBitMap(filePath);

                    imgTempImage.Source = newImage;
                    selectedProduct.Image = newImage;
                    selectedProduct.FilePath = txtEditImagePath.Text;

                    lvProducts.Items.Refresh();
                    Application.Current.MainWindow.Close();

                }
            }
            
            
               
            
        }

        private async void btnEditCatagory_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = lvProducts.SelectedItem as Product;
            if (selectedProduct != null)
            {
                if (rbPetSupplies.IsChecked == true)
                {
                    selectedProduct.Categories1 = Product.Categories.PetSupplies;
                }
                else if(rbFregrance.IsChecked == true)
                {
                    selectedProduct.Categories1 = Product.Categories.Fregance;
                }
                else if (rbTech.IsChecked == true)
                {
                    selectedProduct.Categories1 = Product.Categories.Tech;
                }
                lvProducts.Items.Refresh();
            }
            
        }
    }//end class
}//end namespace
