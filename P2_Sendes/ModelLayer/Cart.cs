using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Cart
    {
        //In DB
        public Guid PK_CartID { get; set; }
        public Guid FK_Product { get; set; }
        public string? CartUser { get; set; }
        public int Quanity { get; set; }
        //In Server
        //public int TotalItems { get; set; }
        public List<Product>? _Cart { get; set; } = new List<Product>();

        public Cart() { }

        public Cart(Guid cartID, Guid fk_Product, string cartUser, int quantity)
        {
            this.PK_CartID = cartID;
            this.FK_Product = fk_Product;
            this.CartUser = cartUser;
            this.Quanity = quantity;
        }
        
    }
}