using System;
using ModelLayer;
using RepoLayer;

namespace BusinessLayer
{
    public class UserAuthentication : IUserAuthentication
    {
        //Import the Repo Layer
        private readonly IADO_Access _repoLayer;
        //private readonly VerifyAnswers verify;
        //private readonly VerifyAnswers verify;
        public UserAuthentication(IADO_Access repoLayer)
        {
            this._repoLayer = repoLayer;
        }


        /// <summary>
        /// This method signs a new user up
        /// --Returns a dynamic (true, false, or error message)
        /// --TRUE if saved
        /// --False if not
        /// 
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public async Task<dynamic?> User_Register(UserRegisterDTO user)
        {
            //Console.WriteLine($"\n\n\n\t\t\tYou are the current user: {username} -- UserAuth Class\n");
            dynamic? newUser = null;
            if (user.Role == Status.User)
            {
                newUser = new User(
                   Guid.NewGuid(),
                   user.Username,
                   user.Password,
                   user.First,
                   user.Last,
                   user.Email,
                   user.Role,
                   DateTime.Now
                   );
            }
            else if(user.Role == Status.Admin)
            {
                newUser = new Admin(
                   Guid.NewGuid(),
                   user.Username,
                   user.Password,
                   user.First,
                   user.Last,
                   user.Email,
                   user.Role,
                   DateTime.Now
                   );
            }
            else
            {
                return null;
            }
            dynamic? verifiedResult = await _repoLayer.Register_User(newUser);
            if (verifiedResult != null)//If the user was  saved
            {//return true
                return verifiedResult;
            }
            else
            {
                return null;
            }



        }//End of USER REGISTER


        /// <summary>
        /// This is the method to log in
        /// --Returns a dynamic (User or Admin)
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<dynamic?> User_Login(UserLoginDTO user)
        {
            //validate username and password to make sure there are no inccoreect entrees
            VerifyAnswers verify = new VerifyAnswers();
            dynamic validater = verify.Verify_API_Form_Data__USERNAME(user.Email, 3, 30);
            if (validater.GetType() == typeof(bool)) //if verification was a success boolean
            {
                Console.WriteLine($"\n\t\tCheck was successful: {validater}\n");
            }
            else// if the verification was not a bool but an error string
            {
                return null; //return the string error message
            }

            validater = verify.Verify_API_Form_Data__PASSWORD(user.Password, 5, 50);
            if (validater.GetType() == typeof(bool)) //if verification was a success boolean
            {
                Console.WriteLine($"\n\t\tCheck was successful: {validater}\n");
            }
            else// if the verification was not a bool but an error string
            {
                return null; //return the string error message
            }
            //going to return a User or a Admin
            dynamic? loggedUser = await this._repoLayer.Login_User(user);
            if (loggedUser != null)
            {
                return loggedUser;
            }
            else
            {
                return null;
            }
        }//End of User LOGIN

        /// <summary>
        /// Checks if the User exists
        /// Returns TRUE if exists
        /// FALSE if not
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> CheckIf_UserExists(string Email)
        {
            bool check = await this._repoLayer.CheckFor_User(Email);
            if (check == true)
            {
                //its true that the user exists already
                Console.WriteLine($"\n\n\t\t{Email} already exists -- Check if Exists -- UserAuth - BL\n");
                return true;
            }
            else
            {
                //the user does not exists
                Console.WriteLine($"\n\n\t\t{Email} does not exist -- Check If Exists -- UserAuth - BL\n");
                return false;
            }
        }
    }
}
