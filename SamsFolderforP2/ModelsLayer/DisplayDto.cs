using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
<<<<<<<< HEAD:SamsFolderforP2/ModelsLayer/DisplayDto.cs
    public class DisplayDto
========
    public class Product
>>>>>>>> main:SamsFolderforP2/ModelsLayer/Product.cs
    {
        public DisplayDto(Guid productID, string productName, string productDetails, decimal productPrice, int productInventory)
        {
            ProductID = productID;
            ProductName = productName;
            ProductDetails = productDetails;
            ProductPrice = productPrice;
            ProductInventory = productInventory;
        }

        public Guid ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductDetails { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductInventory { get; set; }

    }
}
