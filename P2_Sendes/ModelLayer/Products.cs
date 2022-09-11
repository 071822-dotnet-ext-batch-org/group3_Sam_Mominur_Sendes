using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Product
    {
        private Guid pk_ProductID {get;set;}
        private string title {get;set;} = "User";
        private string? description {get;set; } 
        private decimal price {get;set;}
        private int inventory {get;set;}
        private DateTime dateCreated { get; set; }
        private string createdBy { get; set; } = "User";
        //TODO Add user ID foreign key
        //public Guid FK_UserID { get; set; }

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

        public string? Description{
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

        public DateTime DateCreated
        {
            get
            {
                return dateCreated;
            }
            set
            {
                this.dateCreated = value;
            }
        }
        public string CreatedBy
        {
            get
            {
                return createdBy;
            }
            set
            {
                this.createdBy = value;
            }
        }

        /// <summary>
        /// This is the default product
        /// </summary>
        public Product(){}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="price"></param>
        /// <param name="inventory"></param>
        /// <param name="dateCreated"></param>
        /// <param name="userID"></param>
        public Product(Guid id, string title, string description, decimal price, int inventory, DateTime dateCreated, string createdBy){
            PK_ProductID = id;
            Title = title;
            Description = description;
            Price = price;
            Inventory = inventory;
            DateCreated = dateCreated;
            CreatedBy = createdBy;
        }
    }


}