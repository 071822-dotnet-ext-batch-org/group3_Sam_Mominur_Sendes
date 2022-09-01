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
        private readonly IUserAuthentication _userAuth;
        //private readonly IADO_Access _adoAccess_RL;
        public UserProfileController(IUserProfileBL UserProfileinterface, IUserAuthentication UserAuthInterface)
        {
            this._userProfile_BL = UserProfileinterface;
            this._userAuth = UserAuthInterface;
            //this._adoAccess_RL = ADOInterface;
        }
        // GET: /<controller>/
        [HttpPost("CreateProfile")]
        public async Task<ActionResult<string>> User_CreateProfile(UserProfileDTO profile)
        {
            if (ModelState.IsValid)
            {
                dynamic checkIfRegistered = await this._userProfile_BL.User_CreateProfile(profile);
                if (checkIfRegistered.GetType() == typeof(bool))//If the check is a boolean, it was saved successfully
                {
                    if (checkIfRegistered == true)
                    {
                        //User profile was saved
                        //return ;
                        return Created($"\n\t\tYour new profile has been saved {profile.Username}\n", profile);
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
            else
            {
                return BadRequest("\n\t\tYour response was not valid.\n\t\t\tTRY AGAIN!!!\n");
            }
        }


        [HttpGet("ViewProfiles")]
        [HttpGet("ViewProfile/{username?}")]
        public async Task<ActionResult<List<UserProfile>?>> User_ViewAllProfiles(string username = "default")
        {
            if (ModelState.IsValid)
            {
                bool check = await _userAuth.CheckIf_UserExists(username);
                if(check == true)
                {
                    List<UserProfile>? profiles = await _userProfile_BL.User_GetProfiles();
                    return profiles;

                }
                return BadRequest($"\n\t\tThe user '{username}' does not exist. Was this a error on your part? If so...\n\t\t\tTRY AGAIN!!!\n");
                //TODO Add a check if the username is correct before its sent to get the profile
            }
            else
            {
                return BadRequest("\n\t\tYour response was not valid.\n\t\t\tTRY AGAIN!!!\n");
            }
        }

    }

}