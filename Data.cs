using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog122_L15_Final_Review
{
    public static class Data
    {
        //observable collection
        static ObservableCollection<Product> _amazonProducts;

        static Data()
        {
            _amazonProducts = new ObservableCollection<Product>();

            Product newProduct = new Product("Sheeba", "Cat Food", "Sheba", 25.00, "C:\\Users\\rt65s\\Documents\\Software II\\Week 10\\Prog122_L15_Final_Review\\Images\\cat.jpg", 2024, Product.Categories.PetSupplies);
            AddProduct(newProduct);
        }

        public static ObservableCollection<Product> AmazonPoducts { get { return _amazonProducts; } }

        public static void AddProduct(Product product)
        {
            _amazonProducts.Add(product);
        }
    }
}
