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
        [HttpPost("api/[login]")]
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
        [HttpPost("api/[register]")]
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
        /// <returns></returns>
        [HttpGet("api/[products]")] //get all of a type request
        public async Task<ActionResult<List<DisplayDto>>> ProductDisplayAsync()
        {
            List<DisplayDto> productDisplayList = await this._businessLayer.ProductDisplayAsync(); //its in the bussiness Layer, because BusinessLayer deals with all the logics. Due to seperation concern, leave minimum logic as possible
            return Ok(productDisplayList); //returns 200          
        }

        [HttpGet("Single product")]
        public string GetProducts()
        {
            return "single product";
        }
        
        // #4 Cart
        //[HttpPut("Cart")] 
        //public async Task

    }
}
