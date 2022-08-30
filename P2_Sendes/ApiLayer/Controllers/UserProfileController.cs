using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using ModelLayer;
using System.ComponentModel.DataAnnotations;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiLayer.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly IUserProfileBL _userProfile_BL;
        //private readonly IADO_Access _adoAccess_RL;
        public UserProfileController(IUserProfileBL UserProfileinterface)
        {
            this._userProfile_BL = UserProfileinterface;
            //this._adoAccess_RL = ADOInterface;
        }
        // GET: /<controller>/
        [HttpPost("CreateProfile")]
        public async Task<ActionResult<string>> User_CreateProfile(UserProfileDTO profile)
        {
            //TODO Add a check if the username is correct before its sent to get the profile
            dynamic checkIfRegistered = await this._userProfile_BL.User_CreateProfile(profile);
            if (checkIfRegistered.GetType() == typeof(bool))//If the check is a boolean, it was saved successfully
            {
                if (checkIfRegistered == true)
                {
                    //User profile was saved
                    //return ;
                    return Ok($"\n\t\tYour new profile has been saved {profile.Username}\n");
                }
                else
                {
                    //User profile not saved
                    //return ;
                    return Conflict("\n\t\tYour profile was not saved!\n");
                }
            }
            else//If the check wasnt a boolen
            {
                return checkIfRegistered;//return the error message that was returned
            }
        }
        [HttpGet("ViewProfile/{username}/")]
        public async Task<ActionResult<UserProfileDTO>> User_ViewProfile(string username)
        {
            //TODO Add a check if the username is correct before its sent to get the profile
            UserProfileDTO profile = await _userProfile_BL.User_GetProfile(username);
            return profile;
        }
    }
}

