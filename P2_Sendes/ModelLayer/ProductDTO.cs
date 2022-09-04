using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class ProductDTO
    {
        // public Guid PK_ProductID {get;set;}
        [Required(ErrorMessage ="Your product must include a title")]
        [StringLength(30, MinimumLength =3, ErrorMessage ="Your title is too long or short")]
        public string? Title {get;set;}
        [Required(AllowEmptyStrings =true ,ErrorMessage = "Your product must include a description")]
        [StringLength(150, MinimumLength = 0, ErrorMessage = "Your description is too long")]
        public string? Description {get;set;}
        [Required(ErrorMessage ="Price Required")]
        public decimal Price {get;set;}
        [Required(ErrorMessage = "Price Required")]
        public int Inventory {get;set;}
        public string? User { get; set; }
        /// <summary>
        /// This is a default Product 
        /// </summary>
        public ProductDTO(){ }
        /// <summary>
        /// This is a default Product 
        /// </summary>
        public ProductDTO(string title, string descr, decimal price, int invent, string user){
            // PK_ProductID = Guid.NewGuid();
            Title = title;
            Description = descr;
            Price = price;
            Inventory = invent;
            User = user;
        }
    }
}