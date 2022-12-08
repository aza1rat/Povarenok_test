using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OOO_Povarenok
{
    public class Product
    {
        public string productArticle;
        public string productType;
        public int productUnit;
        public string productDescription;
        public int productCategory;
        public Image productPhoto;
        public int productManufacturer;
        public int productProvider;
        public double productCost;
        public int productDiscount;
        public int productMaxDiscount;
        public int productQuantity;

        public Product (string article, string type, int unit, string description, int category, int manufacturer,
            int provider,double cost, int discount, int maxDiscount, int quantity)
        {
            this.productArticle = article;
            this.productType = type;
            this.productUnit = unit;
            this.productDescription = description;
            this.productCategory = category;
            this.productManufacturer = manufacturer;
            this.productProvider = provider;
            this.productCost = cost;
            this.productDiscount = discount;
            this.productMaxDiscount = maxDiscount;
            this.productQuantity = quantity;
        }

        public void InsertImage(Product product, Image image)
        {
            product.productPhoto = image;
        }


    }
}
