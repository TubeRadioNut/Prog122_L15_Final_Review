using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System.Web;
using System.Windows.Media.Imaging;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;

namespace Prog122_L15_Final_Review
{
    public class Product
    {
        public enum Categories { PetSupplies, Fregance, Tech}
        string _name;
        string _description;
        string _manufacturer;
        double _price;
        string _filePath;
        int _dateListed;
        Categories _categories;
        BitmapImage _image;

        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public string Manufacturer { get => _manufacturer; set => _manufacturer = value; }
        public double Price { get => _price; set => _price = value; }
        public string FilePath { get => _filePath; set => _filePath = value; }
        public int DateListed { get => _dateListed; set => _dateListed = value; }
        public Categories Categories1 { get => _categories; set => _categories = value; }
        public BitmapImage Image { get => _image; set => _image = value; }

        public Product(string name, string description, string manufacturer, double price, string filePath, int dateListed, Categories categories)
        {
            _name = name;
            _description = description;
            _manufacturer = manufacturer;
            _price = price;
            _filePath = filePath;
            _dateListed = dateListed;
            _categories = categories;
            _image = GenerateBitMap(_filePath);
        }

        //private BitmapImage GenerateBitMap(string filepath) // Generates the bitmap image
        public static BitmapImage GenerateBitMap(string filePath)
        {
            Uri convertFilePath = new Uri(filePath);

            BitmapImage bitmap = new BitmapImage(convertFilePath);
            return bitmap;
        }



        //public Paragraph FormattedPost() // Displays your fully formatted Art Post to a Rich Text Box
        public FlowDocument FormattedProdcutPost()
        {
            FlowDocument fullDoc = new FlowDocument();
            fullDoc.Blocks.Add(Name_Formatted());
            fullDoc.Blocks.Add(Description_Formatted());
            fullDoc.Blocks.Add(Manufacturer_Formatted());
            fullDoc.Blocks.Add(Price_Formatted());
            fullDoc.Blocks.Add(Date_Formatted());
            fullDoc.Blocks.Add(Catagories_Fomatted());
            return fullDoc;
        }

        
        //private Paragraph name_Formatted() // Format header ( size, font Family ) Option: Color, Weight
        private Paragraph Name_Formatted()
        {
            Paragraph para = new Paragraph();   
            Run run = new Run(_name);
            run.FontSize = 24;
            run.FontWeight = FontWeights.Bold;
            para.Inlines.Add(run);

            return para;
        }
        
        //private Paragraph Description_Formatted() // Format artist( size, font Family ) Option: Color, Weight
        private Paragraph Description_Formatted()
        {
            Paragraph para = new Paragraph();
            Run run = new Run(_description);
            run.FontSize = 14;
            run.FontStyle = FontStyles.Italic;
            para.Inlines.Add(run);
            return para;
        }
        
        //private Paragraph Manufacturer_Formatted() // Format manufacturer( font size, font family) option: color, weight
        private Paragraph Manufacturer_Formatted()
        {
            Paragraph para = new Paragraph();
            Run run = new Run(_manufacturer);
            run.FontSize = 14;
            para.Inlines.Add(run);
            return para;
        }
        //private Paragraph Price_Formattred() // Format price (money $, font size, font Famnly) option: color, weight
        private Paragraph Price_Formatted()
        {
            Paragraph para = new Paragraph();
            Run run = new Run(_price.ToString("C"));
            run.FontSize = 14;
            para.Inlines.Add(run);
            return para;
        }
        //private Paragraph Date_Formatted() // Format datelisted ( size, font Family ) Option: Color, Weight
        private Paragraph Date_Formatted()
        {
            Paragraph para = new Paragraph();
            Run run = new Run(_dateListed.ToString());
            run.FontSize = 8;
            run.FontWeight = FontWeights.Bold;
            para.Inlines.Add(run);
            return para;
        }
        //private Paragraph Catagories_Formatted() // Format catagories( size, font Family ) Option: Color, Weight
        private Paragraph Catagories_Fomatted()
        {
            Paragraph para = new Paragraph();
            Run run = new Run(_categories.ToString());
            run.FontSize = 16;
            run.FontWeight = FontWeights.Bold;
            para.Inlines.Add(run);
            return para;
        }
        //Product
        //Image
        //Name
        //Manufacturer
        //Date Listed
        //Product Description
        //File Path
        //Category
        //Price
        //Enum
    }
}
