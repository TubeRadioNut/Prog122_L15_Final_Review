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
    /// Interaction logic for ProductEntry.xaml
    /// </summary>
    public partial class ProductEntry : Window
    {
        public ProductEntry()
        {
            InitializeComponent();
            PopulateComboBox();
            cmbDate.SelectedIndex = cmbDate.Items.Count - 1;

        }

        

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text;
            string manu = txtManufactuer.Text;
            int date = int.Parse(cmbDate.Text);
            string description = runDescription.Text;
            double price = double.Parse(txtPrice.Text);

            string filePath = txtFilePath.Text;
            Product.Categories category = GetCategory();

            Product tempProduct = new Product(name,description,manu,price,filePath,date,category);
            Data.AddProduct(tempProduct);
            

        }

        public Product.Categories GetCategory()
        {
            if (rbPet.IsChecked == true)
            {
                return Product.Categories.PetSupplies;
            }
            else if (rbFregance.IsChecked == true)
            {
                return Product.Categories.Fregance;
            }
            return Product.Categories.Tech;
        }

        private void PopulateComboBox()
        {
            for (int i = 1950; i < 2025; i++)
            {
                cmbDate.Items.Add(i);
            }
        }

        private void btnImagePath_Click(object sender, RoutedEventArgs e)
        {
            //File Picker
            OpenFileDialog filePicker = new OpenFileDialog();
            //display is drop down | Filter by format
            filePicker.Filter = "Image (*.png, *.jpeg, *.jpg, *.webp)|*.png;*.jpeg;*.jpg;*.webp;";

            //Use an if to check if the user pick a file and said ok
            if(filePicker.ShowDialog() == true )
            {
                string filePath = filePicker.FileName;
                txtFilePath.Text = filePath;

                BitmapImage newImage = Product.GenerateBitMap(filePath);

                imgTempImage.Source = newImage;
            }
        }

        private void btnOpenMainWindow_Click(object sender, RoutedEventArgs e)
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
    }
}
//Controls
//Rich Text Box (Basic)
//Radio Buttons
//Image
//- Not doing date time picker
//Combo Box ( Fill with years )
//File Picker
//Text
