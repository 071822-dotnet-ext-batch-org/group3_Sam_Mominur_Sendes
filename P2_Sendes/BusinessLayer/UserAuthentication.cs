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
        public async Task<dynamic> User_Register(UserRegisterDTO user)
        {
            //Console.WriteLine($"\n\n\n\t\t\tYou are the current user: {username} -- UserAuth Class\n");
            VerifyAnswers verify = new VerifyAnswers();

            //Check if form data is good by validating data
            dynamic verified = verify.Verify_API_Form_Data__USERNAME(user.Username, 3, 30);
            if (verified.GetType() == typeof(bool)) //if verification was a success boolean
            {
                Console.WriteLine($"\n\t\tCheck was successful: {verified}\n");
            }
            else// if the verification was not a bool but an error string
            {
                return verified; //return the string error message
            }

            verified = verify.Verify_API_Form_Data__PASSWORD(user.Password, 5, 50);
            if (verified.GetType() == typeof(bool)) //if verification was a success boolean
            {
                Console.WriteLine($"\n\t\tCheck was successful: {verified}\n");
            }
            else// if the verification was not a bool but an error string
            {
                return verified; //return the string error message
            }

            verified = verify.Verify_API_Form_Data__EMAILS(user.Email, 5, 30);
            if (verified.GetType() == typeof(bool)) //if verification was a success boolean
            {
                Console.WriteLine($"\n\t\tCheck was successful: {verified}\n");
            }
            else// if the verification was not a bool but an error string
            {
                return verified; //return the string error message
            }

            verified = verify.Verify_API_Form_Data__StringsONLY(user.First, 0, 30);
            if (verified.GetType() == typeof(bool)) //if verification was a success boolean
            {
                Console.WriteLine($"\n\t\tCheck was successful: {verified}\n");
            }
            else// if the verification was not a bool but an error string
            {
                return verified; //return the string error message
            }

            verified = verify.Verify_API_Form_Data__StringsONLY(user.Last, 0, 30);
            if (verified.GetType() == typeof(bool)) //if verification was a success boolean
            {
                Console.WriteLine($"\n\t\tCheck was successful: {verified}\n");
            }
            else// if the verification was not a bool but an error string
            {
                return verified; //return the string error message
            }
            dynamic? newUser = null;
            if (user.Role.ToString() == "User")
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
            else
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
            bool verifiedResult = await _repoLayer.Register_User(newUser);
            if (verifiedResult == true)//If the user was  saved
            {//return true
                return true;
            }

            return false;//If user was not saved returrn false



        }//End of USER REGISTER


        /// <summary>
        /// This is the method to log in
        /// --Returns a dynamic (User or Admin)
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<dynamic> User_Login(string username, string password)
        {
            //validate username and password to make sure there are no inccoreect entrees
            VerifyAnswers verify = new VerifyAnswers();
            dynamic validater = verify.Verify_API_Form_Data__USERNAME(username, 3, 30);
            if (validater.GetType() == typeof(bool)) //if verification was a success boolean
            {
                Console.WriteLine($"\n\t\tCheck was successful: {validater}\n");
            }
            else// if the verification was not a bool but an error string
            {
                return validater; //return the string error message
            }

            validater = verify.Verify_API_Form_Data__PASSWORD(password, 5, 30);
            if (validater.GetType() == typeof(bool)) //if verification was a success boolean
            {
                Console.WriteLine($"\n\t\tCheck was successful: {validater}\n");
            }
            else// if the verification was not a bool but an error string
            {
                return validater; //return the string error message
            }




            bool verifiedResult = await CheckIf_UserExists(username);
            if (verifiedResult == false)//If the user does not exist
            {//return 0 | username or pass DNE
                return 0;
            }
            else//the username exists 
            {//try to log in now
                dynamic? loggedUser = await this._repoLayer.Login_User(username, password);
                if (loggedUser != null)//If the username and password matched and the user was gotten
                {
                    return loggedUser;
                }
                return 1;
            }
        }//End of User LOGIN

        /// <summary>
        /// Checks if the User exists
        /// Returns TRUE if exists
        /// FALSE if not
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> CheckIf_UserExists(string username)
        {
            bool check = await this._repoLayer.CheckFor_User(username);
            if (check == true)
            {
                //its true that the user exists already
                Console.WriteLine($"\n\n\t\t{username} already exists -- Check if Exists -- UserAuth - BL\n");
                return true;
            }
            else
            {
                //the user does not exists
                Console.WriteLine($"\n\n\t\t{username} does not exist -- Check If Exists -- UserAuth - BL\n");
                return false;
            }
        }
    }
}
