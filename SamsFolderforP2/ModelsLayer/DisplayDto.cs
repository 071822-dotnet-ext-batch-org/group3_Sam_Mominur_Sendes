using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class DisplayDto
    {
        public DisplayDto(string productName, string productDetails, decimal productPrice, int productInventory)
        {
            ProductName = productName;
            ProductDetails = productDetails;
            ProductPrice = productPrice;
            ProductInventory = productInventory;
        }

        public string ProductName { get; set; }
        public string ProductDetails { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductInventory { get; set; }

    }
}
