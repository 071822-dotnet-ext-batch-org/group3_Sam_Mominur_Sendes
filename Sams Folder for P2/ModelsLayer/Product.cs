using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    internal class Product
    {
        public Product(Guid productID, Guid fK_UserName, string productName, string productDetails, decimal productPrice, int productInventory)
        {
            ProductID = productID;
            FK_UserName = fK_UserName;
            ProductName = productName;
            ProductDetails = productDetails;
            ProductPrice = productPrice;
            ProductInventory = productInventory;
        }

        public Guid ProductID { get; set; }
        public Guid FK_UserName { get; set; }
        public string ProductName { get; set; }
        public string ProductDetails { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductInventory { get; set; }


    }
}
