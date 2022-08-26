using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class Products
    {
      public Products(int product_Id, int user_ID, string product_Name, string product_Description, double product_Price, int product_Inventory)
        {
            productId = product_Id;
            userId = user_ID;
            productName = product_Name;
            productDescription = product_Description;
            productPrice = product_Price;
            productInventory = product_Inventory;
        }

        
        public int productId { get; set; }
        public int userId { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public double productPrice { get; set; }
        public int productInventory { get; set; }




    }


    }
