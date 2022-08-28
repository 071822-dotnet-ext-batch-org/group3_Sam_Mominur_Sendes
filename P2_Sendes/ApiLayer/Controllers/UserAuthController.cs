using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using ModelLayer;


namespace ApiLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAuthController : ControllerBase
    {
        private readonly IUserAuthentication _userAuth_BL;
        public UserAuthController(IUserAuthentication Userinterface)
        {
            this._userAuth_BL = Userinterface; 
        }
        [HttpPost("Register")]
        public async Task<ActionResult<string>> User_Register([FromBody]UserDTO user)
        {
            //IUserAuthentication _userAuth_BL ;
            Console.WriteLine($"\n\n\n\t\t\tYou are the current user: {user.Username} -- UserAuth Controller\n");
            dynamic checkIfRegistered = await this._userAuth_BL.User_Register(user);
            if(checkIfRegistered == true)
            {
                //User profile was saved
                return Ok(checkIfRegistered);
            }
            else
            {
                //User profile not saved
                return Conflict(checkIfRegistered);
            }
        }
    }
}