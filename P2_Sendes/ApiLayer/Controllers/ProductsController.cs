using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using ModelLayer;

using System.Globalization;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProduct_BusinessLayer _prod_BL;
        private readonly IUserAuthentication _userAuth_BL;
        // private static List<Product> prodList = new List<Product>();

        public ProductsController(IProduct_BusinessLayer _repoBL, IUserAuthentication _userBL)
        {
            this._prod_BL = _repoBL;
            this._userAuth_BL = _userBL;
        }
        // GET: api/values
        //[HttpGet("Products")]
        [HttpGet("Products/")]
        public async Task<ActionResult<List<Product>?>> GetProducts()
        {
            if (ModelState.IsValid)
            {
                List<Product>? products = await this._prod_BL.Get_AllProducts();
                return Ok(products);
            }
            else
            {
                return BadRequest("Your request was not valid");
            }
        }//End of list all products

        // POST api/values
        [HttpPost("AddProduct")]
        [Authorize]
        public async Task<ActionResult<string>> Create_Product([FromForm] ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                //TODO check if user exists
                bool check = await this._userAuth_BL.CheckIf_UserExists_W_USERNAME(product.User);
                if(check == true)
                {
                    dynamic? user = await this._userAuth_BL.GET_USER_BY_USERNAME(product.User);
                    if(user != null)
                    {
                        User user1 = new User();
                        user1.Role = Status.Admin;
                        Console.WriteLine($"\n\n\tThe user is an {user.Role.ToString()}\n\n");
                        if(user.Role == Status.Admin)
                        {
                            Product? prod = await this._prod_BL.Add_Product(product);
                            if(prod != null)
                            {
                                return Ok($"Your new Product ID is:" +
                                    $"\nID: {prod.PK_ProductID}" +
                                    $"\nPrice: {prod.Price}\n" +
                                    $"\nDescription: {prod.Description}" +
                                    $"\nFK_USERID: {prod.CreatedBy}");
                            }
                            else
                            {
                                return Conflict("There was a problem when creating your product");
                            }

                        }
                        else
                        {
                            return Conflict($"\n\n\tThe user {product.User} is not an admin and cannot add products\n");
                        }
                    }
                    else
                    {
                        return Conflict($"The user '{product.User}' could not be found");
                    }
                }
                else
                {
                    return Conflict($"The username '{product.User}' could not be found");
                }
            }
            else
            {
                return BadRequest("The model response was not valid");
            }
        }//End of Create a product


    }
}

