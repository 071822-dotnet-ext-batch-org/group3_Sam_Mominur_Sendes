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
        /// Returns TRUE if saved
        /// False if not
        /// 
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        public async Task<dynamic> User_Register(UserDTO userDTO)
        {
            Console.WriteLine($"\n\n\n\t\t\tYou are the current user: {userDTO.Username} -- UserAuth Class\n");
            VerifyAnswers verify = new VerifyAnswers();

            //Check if form data is good by validating data
            dynamic verified = verify.Verify_API_Form_Data__USERNAME(userDTO.Username, 3, 30);
            if(verified.GetType() == typeof(bool)) //if verification was a success boolean
            {
                Console.WriteLine($"\n\t\tCheck was successful: {verified}\n");
            }
            else// if the verification was not a bool but an error string
            {
                return verified; //return the string error message
            }

            verified = verify.Verify_API_Form_Data__PASSWORD(userDTO.Password, 5, 30);
            if (verified.GetType() == typeof(bool)) //if verification was a success boolean
            {
                Console.WriteLine($"\n\t\tCheck was successful: {verified}\n");
            }
            else// if the verification was not a bool but an error string
            {
                return verified; //return the string error message
            }

            verified = verify.Verify_API_Form_Data__EMAILS(userDTO.Email, 5, 30);
            if (verified.GetType() == typeof(bool)) //if verification was a success boolean
            {
                Console.WriteLine($"\n\t\tCheck was successful: {verified}\n");
            }
            else// if the verification was not a bool but an error string
            {
                return verified; //return the string error message
            }

            verified = verify.Verify_API_Form_Data__StringsONLY(userDTO.First, 0, 30);
            if (verified.GetType() == typeof(bool)) //if verification was a success boolean
            {
                Console.WriteLine($"\n\t\tCheck was successful: {verified}\n");
            }
            else// if the verification was not a bool but an error string
            {
                return verified; //return the string error message
            }

            verified = verify.Verify_API_Form_Data__StringsONLY(userDTO.Last, 0, 30);
            if (verified.GetType() == typeof(bool)) //if verification was a success boolean
            {
                Console.WriteLine($"\n\t\tCheck was successful: {verified}\n");
            }
            else// if the verification was not a bool but an error string
            {
                return verified; //return the string error message
            }


            User newUser = new User(userDTO);

            bool verifiedResult = await _repoLayer.Register_User(newUser);
            if(verifiedResult == true)//If the user was  saved
            {//return true
                return true;
            }

            return false;//If user was not saved returrn false



        }//End of USER REGISTER

        public async Task<dynamic> User_Login(string username, string password)
        {
            //validate username and password to make sure there are no inccoreect entrees
            VerifyAnswers verify = new VerifyAnswers();
            dynamic validater = verify.Verify_API_Form_Data__USERNAME(username, 0, 30);
            if (validater.GetType() == typeof(bool)) //if verification was a success boolean
            {
                Console.WriteLine($"\n\t\tCheck was successful: {validater}\n");
            }
            else// if the verification was not a bool but an error string
            {
                return validater; //return the string error message
            }

            validater = verify.Verify_API_Form_Data__PASSWORD(password, 0, 30);
            if (validater.GetType() == typeof(bool)) //if verification was a success boolean
            {
                Console.WriteLine($"\n\t\tCheck was successful: {validater}\n");
            }
            else// if the verification was not a bool but an error string
            {
                return validater; //return the string error message
            }

            //after validation is passed, check if username exists before loggin in
            User newUser = new User()
            {
                Username = username,
                Password = password
            };

            Console.WriteLine($"{newUser.Username},   {newUser.Password}");

            bool verifiedResult = await CheckIf_UserExists(username);
            if (verifiedResult == false)//If the user does not exist
            {//return 0 | username or pass DNE
                return 0;
            }
            else//the username exists 
            {//try to log in now
                User? loggedUser = await this._repoLayer.Login_User(username, password);
                if(loggedUser != null)//If the username and password matched and the user was gotten
                {
                    return 2;
                }
                return 1;
            }




        }

        /// <summary>
        /// Checks if the User exists
        /// Returns TRUE if exists
        /// FALSE if not
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> CheckIf_UserExists(string username)
        {
            User checkedUser = new User()
            {
                Username = username
            };
            Console.WriteLine($"{checkedUser.Username}");
            var check = await this._repoLayer.CheckFor_User(checkedUser);
            if(check == true)
            {
                //its true that the user exists already
                Console.WriteLine($"\n\n\t\t{checkedUser.Username} already exists -- Check if Exists -- UserAuth - BL\n");
                return true;
            }
            else
            {
                //the user does not exists
                Console.WriteLine($"\n\n\t\t{checkedUser.Username} does not exist -- Check If Exists -- UserAuth - BL\n");
                return false;
            }
        }
    }
}

