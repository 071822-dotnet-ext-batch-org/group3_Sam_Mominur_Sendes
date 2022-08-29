using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class Products
    {
      public Products(Guid product_Id, Guid fk_user_ID, string product_Name, string product_Details, double product_Price, int product_Inventory)
        {
            ProductID = product_Id;
            FK_UserID = fk_user_ID;
            ProductName = product_Name;
            ProductDetails = product_Details;
            ProductPrice = product_Price;
            ProductInventory = product_Inventory;
        }

        
        public Guid ProductID { get; set; }
        public Guid FK_UserID { get; set; }
        public string ProductName { get; set; }
        public string ProductDetails { get; set; }
        public double ProductPrice { get; set; }
        public int ProductInventory { get; set; }




    }


    }
