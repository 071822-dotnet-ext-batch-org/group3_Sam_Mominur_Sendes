using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class Products
    {
        public Products(Guid productID, Guid fK_UserID, string productName, string productDetails, decimal productPrice, int productInventory)
        {
            ProductID = productID;
            FK_UserID = fK_UserID;
            ProductName = productName;
            ProductDetails = productDetails;
            ProductPrice = productPrice;
            ProductInventory = productInventory;
        }

        public Guid ProductID { get; set; }
        public Guid FK_UserID { get; set; }
        public string ProductName { get; set; }
        public string ProductDetails { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductInventory { get; set; }
    

    }
        
    
}