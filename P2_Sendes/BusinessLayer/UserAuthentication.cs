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
            var verified = verify.Verify_API_Form_Data__StringsONLY(userDTO.Username, 3, 30);
            if(verified != true) // if the verification failed
            {
                return verified; // return the error message
            }

            verified = verify.Verify_API_Form_Data__PASSWORD(userDTO.Password, 3, 30);
            if (verified != true) // if the verification failed
            {
                return verified; // return the error message
            }

            verified = verify.Verify_API_Form_Data__LongResponse(userDTO.Email, 5, 30);
            if (verified != true) // if the verification failed
            {
                return verified; // return the error message
            }

            verified = verify.Verify_API_Form_Data__StringsONLY(userDTO.First, 5, 30);
            if (verified != true) // if the verification failed
            {
                return verified; // return the error message
            }

            verified = verify.Verify_API_Form_Data__StringsONLY(userDTO.Last, 5, 30);
            if (verified != true) // if the verification failed
            {
                return verified; // return the error message
            }


            User newUser = new User(userDTO);

            verified = await _repoLayer.Register_User(newUser);
            if(verified != true)//If the user was not saved
            {//return the failed message
                return verified;
            }

            return verified;//If user was saved successfully return the response message



        }
    }
}

