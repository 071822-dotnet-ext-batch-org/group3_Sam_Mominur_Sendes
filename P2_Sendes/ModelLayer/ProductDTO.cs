using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class ProductDTO
    {
        // public Guid PK_ProductID {get;set;}
        public string Title {get;set;}
        public string Description {get;set;}
        public decimal Price {get;set;}
        public int Inventory {get;set;}
        
        /// <summary>
        /// This is a default Product 
        /// </summary>
        public ProductDTO(string title, string desc, decimal price, int inventory){
            // PK_ProductID = Guid.NewGuid();
            this.Title = title;
            this.Description = desc;
            this.Price = price;
            this.Inventory = inventory;
        }
    }
}