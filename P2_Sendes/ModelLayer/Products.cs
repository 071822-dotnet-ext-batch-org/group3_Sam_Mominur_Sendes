using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Product
    {
        private Guid pk_ProductID {get;set;}
        private string title {get;set;}
        private string description {get;set;}
        private decimal price {get;set;}
        private int inventory {get;set;}

        public Guid PK_ProductID{
            get{
                return pk_ProductID;
            }
            set{
                this.pk_ProductID = value;
            }
        }


        public string Title{
            get{
                return title;
            }
            set{
                this.title = value;
            }
        }

        public string Description{
            get{
                return description;
            }
            set{
                this.description = value;
            }
        }


        public decimal Price{
            get{
                return price;
            }
            set{
                this.price = value;
            }
        }


        public int Inventory{
            get{
                return inventory;
            }
            set{
                this.inventory = value;
            }
        }

        /// <summary>
        /// This is a default Product 
        /// </summary>
        public Product(){
            PK_ProductID = Guid.NewGuid();
            Title = "Product Name";
            Description = "Product Description";
            Price = 0;
            Inventory = 0;
        }

        /// <summary>
        /// This is a product that gets created by a user IN THE APP
        /// </summary>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="inventory"></param>
        public Product(string title, string description, decimal price, int inventory){
            PK_ProductID = Guid.NewGuid();
            Title = title;
            Description = description;
            Price = price;
            Inventory = inventory;
        }

        /// <summary>
        /// This is a product that gets loaded FROM the database
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="inventory"></param>
        public Product(Guid ID, string title, string description, decimal price, int inventory){//This is a product that gets loaded FROM the Database
            PK_ProductID = ID;
            Title = title;
            Description = description;
            Price = price;
            Inventory = inventory;
        }
    }


}