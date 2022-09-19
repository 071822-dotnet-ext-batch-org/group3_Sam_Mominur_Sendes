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
        public async Task<User?> User_Register(UserRegisterDTO user)
        {
            //Console.WriteLine($"\n\n\n\t\t\tYou are the current user: {username} -- UserAuth Class\n");
            
            User newUser = new User(
                Guid.NewGuid(),
                user.Username,
                user.Password,
                user.First,
                user.Last,
                user.Email,
                Status.User,
                DateTime.Now
                );
            User? verifiedResult = await _repoLayer.Register_User(newUser);
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

        public async Task<bool> CheckIf_UserExists_W_USERNAME(string Username)
        {
            bool check = await this._repoLayer.CheckFor_User_W_USERNAME(Username);
            if (check == true)
            {
                //its true that the user exists already
                Console.WriteLine($"\n\n\t\t{Username} already exists -- Check if Exists -- UserAuth - BL\n");
                return true;
            }
            else
            {
                //the user does not exists
                Console.WriteLine($"\n\n\t\t{Username} does not exist -- Check If Exists -- UserAuth - BL\n");
                return false;
            }
        }

        public async Task<dynamic?> GET_USER_BY_USERNAME(string Username)
        {
            dynamic? check = await this._repoLayer.Get_User_w_USERNAME(Username);
            if(check != null)
            {
                return check;
            }
            else
            {
                return null;
            }
        }//End of Check if exists with Username

        public async Task<List<dynamic>?> GetAll_Users()
        {
            return await this._repoLayer.Get_ALL_USERS();
        }//End get all users
    }//End class

}
