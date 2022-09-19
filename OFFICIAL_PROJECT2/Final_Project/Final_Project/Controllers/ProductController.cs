using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

//Imported
using System.ComponentModel.DataAnnotations;
using System.Globalization;

//My Imports
using ModelLayer;
using BusinessLayer;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Final_Project.Controllers
{
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProduct_BusinessLayer PBL;
        private IUser_BusinessLayer UBL;
        public ProductController(IProduct_BusinessLayer p_BL, IUser_BusinessLayer u_BL)
        {
            this.PBL = p_BL;
            this.UBL = u_BL;
        }

        /// <summary>
        /// This controller will get all the products
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Models.FrontEnd_Product>?>> GetProducts()
        {
            List<Models.Product>? ALL_private_PRODUCTS = await this.PBL.GetProducts();
            List<Models.FrontEnd_Product> publicProducts = new List<Models.FrontEnd_Product>();
            if(ALL_private_PRODUCTS != null)
            {
                foreach(Models.Product product in ALL_private_PRODUCTS)
                {
                    Models.FrontEnd_Product publicProduct = new Models.FrontEnd_Product(
                        product.ID,
                        product.Title,
                        product.Description,
                        product.Price,
                        product.Inventory,
                        product.DateAdded
                        );
                    publicProducts.Add(publicProduct);
                }
                return Ok(publicProducts);
            }
            else
            {
                return Ok(publicProducts);
            }
        }//END GET ALL PRODUCTS


        [HttpPost("add")]
        public async Task<ActionResult<bool>> CreateProduct(Models.FrontEnd_Product product, string Email)
        {
            if (ModelState.IsValid)
            {
                List<Models.User> users = await this.UBL.GetUsers();
                if(users != null)
                {
                    bool check_If_Exists = users.Exists(user => user.Email == Email);
                    if(check_If_Exists == true)
                    {
                        Models.User user = users.Find(user => user.Email == Email);
                        List<Models.Product>? ALL_private_PRODUCTS = await this.PBL.GetProducts();
                        product.Title.Trim();
                        product.Description.Trim();
                        bool check_for_Name = ALL_private_PRODUCTS.Exists(existingProduct => existingProduct.Title == product.Title);

                        if(check_for_Name == false)
                        {
                            bool check_If_Saved = await this.PBL.CreateProduct(product, user.Username);
                            if(check_If_Saved == true)
                            {
                                return Created("",check_If_Saved);
                            }
                            else
                            {
                                return Conflict($"Your product could not be saved: {check_If_Saved}");
                            }
                        }
                        else
                        {
                            return Conflict($"The there is already a product named {product.Title}");
                        }
                    }
                    else
                    {
                        return Conflict($"The user with email {Email:C2} user does not exist");
                    }
                }
                else
                {
                    return Conflict($"The user with email {Email:C2} user does not exist");
                }
            }
            else
            {
                return BadRequest("Your new product could not be saved due to a bad request");
            }
        }

    }
}

