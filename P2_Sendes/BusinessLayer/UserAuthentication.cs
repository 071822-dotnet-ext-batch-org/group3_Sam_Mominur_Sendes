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
            //UserDTO newUserDTO = new UserDTO()
            //{
            //    Username = userDTO.Username,
            //    Password = userDTO.Password,
            //    Email = userDTO.Email,
            //    First = userDTO.First,
            //    Last = userDTO.Last
            //};
            //newUserDTO = userDTO;

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

        /// <summary>
        /// Checks if the User exists
        /// Returns TRUE if exists
        /// FALSE if not
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<bool> CheckIf_UserExists(UserDTO user)
        {
            User checkedUser = new User(user);
            var check = await this._repoLayer.CheckFor_User(checkedUser);
            if(check == true)
            {
                //its true that the user exists already
                return true;
            }
            else
            {
                //the user does not exists
                return false;
            }
        }
    }
}

