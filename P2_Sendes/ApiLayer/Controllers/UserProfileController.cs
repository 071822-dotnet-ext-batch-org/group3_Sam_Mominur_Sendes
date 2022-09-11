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
        public async Task<ActionResult<UserProfile>?> User_CreateProfile([FromForm] UserProfileDTO profile)
        {
            if (ModelState.IsValid)
            {
                bool checkIfExists = await this._userAuth.CheckIf_UserExists_W_USERNAME(profile.Username);
                if (checkIfExists == true)
                {
                    UserProfile? checkIfRegistered = await this._userProfile_BL.User_CreateProfile(profile);
                    if (checkIfRegistered != null)
                    {
                        //User profile was saved
                        //return ;
                        return Ok(checkIfRegistered);
                    }
                    else
                    {
                        //User profile not saved
                        //return ;
                        return Conflict("\n\t\tYour profile was not saved!\n");
                    }

                }
                else
                {
                    return Conflict($"The username '{profile.Username}' does not exist");
                }
            }
            else
            {
                return BadRequest("\n\t\tYour response was not valid.\n\t\t\tTRY AGAIN!!!\n");
            }
        }


        [HttpGet("ViewProfile/{username?}")]
        public async Task<ActionResult<List<UserProfile>?>> User_ViewAllProfiles([FromRoute] string? username = "default")
        {
            if (ModelState.IsValid)
            {
                if(username == "default")
                {
                    List<UserProfile>? profiles = await this._userProfile_BL.User_GetProfiles();
                    Console.WriteLine("\n\n\tAll profiles were sent\n\n");
                    return profiles;
                }
                else
                {
                    bool check = await _userAuth.CheckIf_UserExists_W_USERNAME(username);
                    if (check == true)
                    {
                        List<UserProfile>? profiles = await this._userProfile_BL.User_GetProfiles();
                        List<UserProfile> sentList = new List<UserProfile>();
                        UserProfile? profile = profiles?.Find(x => x?.Username == username);
                        sentList.Add(profile);
                        Console.WriteLine("\n\n\tUser's profile was sent\n\n");
                    
                        return sentList;

                    }
                    return BadRequest($"\n\t\tThe user '{username}' does not exist. Was this a error on your part? If so...\n\t\t\tTRY AGAIN!!!\n");
                }
            }
            else
            {
                return BadRequest("\n\t\tYour response was not valid.\n\t\t\tTRY AGAIN!!!\n");
            }
        }


        [HttpPut("EditProfile")]
        public async Task<ActionResult<UserProfile>?> User_EditProfile([FromForm] UserProfileDTO profile)
        {
            if (ModelState.IsValid)
            {
                List<UserProfile>? profiles = await this._userProfile_BL.User_GetProfiles();
                if(profiles != null)
                {
                    bool checkIfExists = await this._userAuth.CheckIf_UserExists_W_USERNAME(profile.Username);
                    if (checkIfExists == true)
                    {
                        bool? checkIfProfileEdited = await this._userProfile_BL.User_EditProfile(profile);
                        if (checkIfProfileEdited == true)
                        {
                            List<UserProfile>? Updatedprofiles = await this._userProfile_BL.User_GetProfiles();
                            if(Updatedprofiles != null)
                            {
                                UserProfile? myprofile = Updatedprofiles.Find(x => x.Username == x.Username);

                                //User profile was saved
                                //return ;
                                return Ok(myprofile);
                            }
                            else
                            {
                                return Conflict("There was an error retrieving the profiles");
                            }
                        }
                        else
                        {
                            //User profile not saved
                            //return ;
                            return Conflict("\n\t\tYour profile was not saved!\n");
                        }

                    }
                    else
                    {
                        return Conflict($"The username '{profile.Username}' does not exist");
                    }

                }
                else
                {
                    return Conflict("There are no profiles to edit");
                }
            }
            else
            {
                return BadRequest("\n\t\tYour response was not valid.\n\t\t\tTRY AGAIN!!!\n");
            }
        }

    }

}