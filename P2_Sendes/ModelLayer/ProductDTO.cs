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
        public ProductDTO(){
            // PK_ProductID = Guid.NewGuid();
            Title = "Product Name";
            Description = "Product Description";
            Price = 0;
            Inventory = 0;
        }
        /// <summary>
        /// This is a default Product 
        /// </summary>
        public ProductDTO(Product product){
            // PK_ProductID = Guid.NewGuid();
            Title = product.Title;
            Description = product.Description;
            Price = product.Price;
            Inventory = product.Inventory;
        }
    }
}