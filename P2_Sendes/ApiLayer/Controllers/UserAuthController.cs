using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using ModelLayer;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;
//using RepoLayer;


namespace ApiLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAuthController : ControllerBase
    {
        private readonly IUserAuthentication _userAuth_BL;
        //private readonly TextInfo _stringManipulation;//For Capital letters in string
        //private TextInfo() { }
        //private readonly IADO_Access _adoAccess_RL;
        public UserAuthController(IUserAuthentication UserAuthinterface)
        {
            this._userAuth_BL = UserAuthinterface;
            //this._stringManipulation = new TextInfo();
            //this._adoAccess_RL = ADOInterface;
        }

        //--------------------------------------------Endpoints Section----------------------





        /// <summary>
        /// This method will check if a username exists and register the user if it doesnt
        ///
        /// This returns a string message letting the user know if their account was saved or not
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("Register/")]
        public async Task<ActionResult<User>> User_Register([FromForm] UserRegisterDTO user)
        {
            if (ModelState.IsValid)
            {
                //TODO WHy did this return null reference?
                bool checkIfExists = await this._userAuth_BL.CheckIf_UserExists(user.Email);
                if (checkIfExists == true)//If check says it found a user already with that username
                {
                    //return this error message
                    return Conflict("This user is registered already");
                }
                else//If the check says no present username matches
                {
                    //username is free to be added
                    User? checkIfRegistered = await this._userAuth_BL.User_Register(user);
                    if (checkIfRegistered != null)//If the check is a boolean, it was saved successfully
                    {
                        return Ok(checkIfRegistered);
                    }
                    else//If the check wasnt a boolen
                    {
                        return Conflict("Your account could not be saved");//return the error message that was returned
                    }
                }

            }
            else
            {
                return BadRequest("\n\t\tYour account was not saved due to an invalid input!!!\n");
            }
        }//End of User Register


        [HttpGet("Login/{Email}/{Password}")]
        public async Task<ActionResult<dynamic>> User_Login( [FromRoute]UserLoginDTO user)//returns user 
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine($"{user.Email} will be checked first - API LAYER ");
                bool check = await this._userAuth_BL.CheckIf_UserExists(user.Email);
                if (check == true)
                {
                    dynamic? isLoggedIn = await this._userAuth_BL.User_Login(user);
                    if (isLoggedIn != null)
                    {
                        return Ok(isLoggedIn);
                    }
                    else
                    {
                        return Conflict($"The password used for email '{user.Email}' did not match your response");
                    }
                }
                else
                {
                    return NotFound($"The user with email '{user.Email}' was not found");
                }
            }
            else
            {
                return BadRequest("\n\n\t\t\tUh-nooo...Invalid input!!!\n");
            }

        }//End of Login

        [HttpGet("Users")]
        [Authorize("read:user")]
        public async Task<ActionResult<List<dynamic>>> GetUsers()
        {
            var responGetAll = await this._userAuth_BL.GetAll_Users();
            return Ok(responGetAll);
        }
        [HttpGet("Users/{Email}")]
        public async Task<ActionResult<dynamic>> GetUsers([FromRoute]string Email)
        {
            var responGetAll = await this._userAuth_BL.GetAll_Users();
            Console.WriteLine($"\n\n\n\t\t{responGetAll}\n\n\n");
            

            if(responGetAll == null){
                return NotFound(responGetAll);
            }
            
            foreach(dynamic user1 in responGetAll){
                Console.WriteLine($"\n\n\n\t\t{user1.Email} : vs : {Email}\n\n\n");
                // user.Email
                if(user1.Email == Email)
                {
                    Console.WriteLine($"\n\n\n\t\t{user1}\n\n\n");
                    return Ok(user1);
                }
                // return NotFound(responGetAll);
            }
            return Ok(responGetAll);
        }

    }
}