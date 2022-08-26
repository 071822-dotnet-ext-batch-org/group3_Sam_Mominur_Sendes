using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class Products
    {
      public Product(int productId, int userId, string productName, string productDescription, double productPrice, int productInventory)
        {
            productId = productId;
            userId = userId;
            productName = productName;
            productDescription = productDescription;
            productPrice = productPrice;
            productInventory = productInventory;
        }

        
        public int productId { get; set; }
        public int userId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public double productPrice { get; set; }
        public int productInventory { get; set; }




    }


    }
