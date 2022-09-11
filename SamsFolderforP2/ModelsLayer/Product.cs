using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModelsLayer
{
    public class Product
    {
        //public Product(Guid productID, string productName, string productDetails, decimal productPrice, string imageUrl, int categoryID, Category category)
        //{
        //    ProductID = productID;
        //    ProductName = productName;
        //    ProductDetails = productDetails;
        //    ProductPrice = productPrice;
        //    ImageUrl = imageUrl;
        //    CategoryID = categoryID;
        //    Category = category;
        //}

        public Guid ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDetails { get; set; }
        [Required]
        public decimal ProductPrice { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }
        public int CategoryID { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
        /* <ValidatedNever> Indicates that a property or parameter should be excluded from validation. When applied to a property, 
                         * the validation system excludes that property. When applied to a parameter, the validation system excludes 
                         * that parameter. When applied to a type, the validation system excludes all properties within that type.*/


    }
}
