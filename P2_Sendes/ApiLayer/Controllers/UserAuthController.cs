using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using ModelLayer;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
//using RepoLayer;


namespace ApiLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserAuthController : ControllerBase
    {
        private readonly IUserAuthentication _userAuth_BL;
        private readonly TextInfo _stringManipulation;//For Capital letters in string
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
        public async Task<ActionResult<string>> User_Register([FromForm] UserRegisterDTO user)
        {
            if (ModelState.IsValid)
            {
                //TODO WHy did this return null reference?
                //this._stringManipulation.ToTitleCase(user.Username) 
                Console.WriteLine($"\n\n\t\tCurrent User is: {user.Username}\n\n\n");
                //_stringManipulation = new TextInfo();
                bool checkIfExists = await this._userAuth_BL.CheckIf_UserExists(user.Username);
                if (checkIfExists == true)//If check says it found a user already with that username
                {
                    //return this error message
                    return $"\n\t\tThe user named {user.Username} is registered already.\n\n\t\t\tTRY ANOTHER NAME!!!\n";
                }
                else//If the check says no present username matches
                {
                    //username is free to be added
                    dynamic checkIfRegistered = await this._userAuth_BL.User_Register(user);
                    if (checkIfRegistered.GetType() == typeof(bool))//If the check is a boolean, it was saved successfully
                    {
                        if (checkIfRegistered == true)
                        {
                            //User profile was saved
                            //return ;
                            return Ok(checkIfRegistered);
                        }
                        else
                        {
                            //User profile not saved
                            //return ;
                            return Conflict("\n\t\tYour account was not saved!\n");
                        }
                    }
                    else//If the check wasnt a boolen
                    {
                        return checkIfRegistered;//return the error message that was returned
                    }
                }

            }
            else
            {
                return Conflict("\n\t\tYour account was not saved due to an invalid input!!!\n");
            }
        }//End of User Register


        //[HttpGet("Login/")]//UserName={username}&Password={password}/")]

        [HttpGet("Login/{Username}/{Password}")]
        public async Task<ActionResult<dynamic>> User_Login(UserLoginDTO username)
        {
            if (ModelState.IsValid)
            {
                dynamic isLoggedIn = await this._userAuth_BL.User_Login(username.Username, username.Password);
                if (isLoggedIn.GetType() == typeof(int)) //if verification was a success boolean
                {
                    Console.WriteLine($"\n\t\tCheck was not an immediate error, returning an int response: {isLoggedIn}\n");
                    if (isLoggedIn == 0)//Both username and password are incorrect
                    {
                        return Conflict($"\n\t\tThe username matching '{username.Username}' and/or password was incorrect\n");
                    }
                    else if (isLoggedIn == 1)//The password ONLY was incorrect
                    {
                        return Conflict($"\n\t\tThe password matching '{username}' was incorrect.\n\n\t\t\tTRY AGAIN!!\n");
                    }
                    else
                    {
                        return BadRequest("\n\n\t\t\tUh-oh...Something went wrong!!!\n");
                    }
                }
                else if (isLoggedIn.GetType() == typeof(User))//The username and password are correct
                {
                    return Ok(isLoggedIn);
                }
                else if (isLoggedIn.GetType() == typeof(Admin))//The username and password are correct
                {
                    return Ok(isLoggedIn);
                }
                else// if the verification was not a int but an error string
                {
                    return isLoggedIn; //return the string error message
                }
            }
            else
            {
                return BadRequest("\n\n\t\t\tUh-nooo...There was a validation!!!\n");
            }

        }//End of Login
    }
}