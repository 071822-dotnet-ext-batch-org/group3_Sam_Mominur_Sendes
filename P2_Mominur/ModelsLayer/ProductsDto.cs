using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class ProductsDto
    {
         public ProductsDto( string product_Name, string product_Details, double product_Price, int product_Inventory)
        {

            ProductName = product_Name;
            ProductDetails = product_Details;
            ProductPrice = product_Price;
            ProductInventory = product_Inventory;
        }


        public string ProductName { get; set; }
        public string ProductDetails { get; set; }
        public double ProductPrice { get; set; }
        public int ProductInventory { get; set; }

    
    }
}