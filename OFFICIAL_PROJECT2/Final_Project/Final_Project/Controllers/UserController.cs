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
    public class UserController : ControllerBase
    {
        private IUser_BusinessLayer UBL;
        public UserController(IUser_BusinessLayer u_BL)
        {
            this.UBL = u_BL;
        }

        //TODO This needs access from Admin ONLY
        /// <summary>
        /// This controller returns all the users 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<Models.User>>> GetUsers()
        {
            List<Models.User>? ALL_USERS = await this.UBL.GetUsers();
            return Ok(ALL_USERS);
        }//END GET ALL USERS

        /// <summary>
        /// This controller registers the user with a register DTO
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<ActionResult<Models.User>?> RegisterUser(REGISTERDTO newUser)
        {
            if (ModelState.IsValid)
            {
                List<Models.User> ALL_USERS = await this.UBL.GetUsers();
                if (ALL_USERS != null)
                {
                    bool check_If_Exists = ALL_USERS.Exists((user) => { return user.Email == newUser.Email; });
                    if (check_If_Exists == false)
                    {
                        Models.User? newlyCreatedUser = await this.UBL.RegisterUser(newUser);
                        if (newlyCreatedUser != null)
                        {
                            return Created("account", newlyCreatedUser);
                        }
                        else
                        {
                            return Conflict("Your user could not be registered due to an error");
                        }
                    }
                    else
                    {
                        return Conflict($"This user  with the email {newUser.Email} exists already.\nWhy dont you try another one!");
                    }
                }
                else
                {
                    Models.User? newlyCreatedUser = await this.UBL.RegisterUser(newUser);
                    if (newlyCreatedUser != null)
                    {
                        return Created("account", newlyCreatedUser);
                    }
                    else
                    {
                        return Conflict("Your user could not be registered due to an error");
                    }
                }
            }
            else
            {
                return BadRequest($"Your response was a bad request: \n{newUser}");
            }

        }//END OF REGISTER


        [HttpGet("login")]
        public async Task<ActionResult<Models.User>> LoginUser(LOGINDTO prevUser)
        {
            if(ModelState.IsValid)
            {
                List<Models.User> ALL_USERS = await this.UBL.GetUsers();
                if (ALL_USERS != null)
                {
                    Models.User? returningUser = ALL_USERS.Find(user => user.Email == prevUser.Email);

                    if (returningUser != null)
                    {
                        return Ok(returningUser);
                    }
                    else
                    {
                        return NotFound($"\n\n\t\tThe user with the email {prevUser.Email} could not be found\n\n");
                    }
                }
                else
                {
                    return BadRequest($"\n\n\t\tThe user with the email {prevUser.Email} could not be found\n\n");
                }
            }
            else
            {
                return BadRequest("That was a bad request!!!");
            }


        }
    }
}

