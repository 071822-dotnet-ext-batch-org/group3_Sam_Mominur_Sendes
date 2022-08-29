using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer;
using System.Net.Sockets;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ECommerceAPIController : ControllerBase
    {
        private readonly Business _businessLayer;
        public ECommerceAPIController()
        {
            this._businessLayer = new Business();
        }
        
        /// <summary>
        /// #1 Login as an Admin or User by using Username and Password
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<ActionResult<List<LoginDto>>> LoginAsync(LoginDto login)
        {
            if (ModelState.IsValid)
            {
                LoginDto loginDto = await this._businessLayer.LoginAsync(login);
                return Ok(loginDto);
            }
            else return Conflict(login);
        }

        /// <summary>
        /// #2 New Account registration (Must ensure the username is not already registered & Default employee role)
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPost("Register a New Account")]
        public async Task<ActionResult<List<User>>> NewUserAsync(User newUser)
        {
            if (ModelState.IsValid)
            {
                User user = await this._businessLayer.NewUserAsync(newUser);
                return Ok(user);
            }
            else return Conflict(newUser);
        }

        /// <summary>
        /// #3 Display products
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="productInventory"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Products")] //get all of the products
        public async Task<ActionResult<List<Product>>> ProductsAsync(int productInventory, Guid? id)
        {
            List<Product> productList = await this._businessLayer.ProductsAsync(productInventory); //its in the bussiness Layer, because BusinessLayer deals with all the logics. Due to seperation concern, leave minimum logic as possible
            return Ok(productList); //returns 200
            //return null;
            //0=pending, 1=Aprroved, 2=Denied

        }

    }
}
