using System;
using ModelLayer;
using RepoLayer;
namespace BusinessLayer
{
    public class UserProfileBL : IUserProfileBL
    {
        private readonly IADO_Access _repoLayer;
        //private readonly VerifyAnswers verify;
        //private readonly VerifyAnswers verify;
        public UserProfileBL(IADO_Access repoLayer)
        {
            this._repoLayer = repoLayer;
        }

        public async Task<dynamic> User_CreateProfile(UserProfileDTO profile)
        {
            VerifyAnswers verify = new VerifyAnswers();

            //Check if form data is good by validating data
            dynamic verified = verify.Verify_API_Form_Data__USERNAME(profile.Username, 3, 30);
            if (verified.GetType() == typeof(bool)) //if verification was a success boolean
            {
                Console.WriteLine($"\n\t\tCheck was successful: {verified}\n");
            }
            else// if the verification was not a bool but an error string
            {
                return verified; //return the string error message
            }

            verified = verify.Verify_API_Form_Data__LongResponse(profile.About, 5, 150);
            if (verified.GetType() == typeof(bool)) //if verification was a success boolean
            {
                Console.WriteLine($"\n\t\tCheck was successful: {verified}\n");
            }
            else// if the verification was not a bool but an error string
            {
                return verified; //return the string error message
            }


            UserProfile newUserProfile = new UserProfile()
            {
                FK_UserID = Guid.NewGuid(),
                Username = profile.Username,
                About = profile.About

            };
            bool verifiedResult = await _repoLayer.Create_UserProfile(newUserProfile);
            if (verifiedResult == true)//If the user was  saved
            {//return true
                return true;
            }

            return false;//If user was not saved returrn false


        }

        public async Task<UserProfileDTO?> User_GetProfile(string username)
        {
            UserProfile? loadedProfile = await this._repoLayer.Get_UserProfile(username);
            if (loadedProfile != null)//If the username matched and the Profile was gotten
            {
                UserProfileDTO profile = new UserProfileDTO(loadedProfile.Username, loadedProfile.About);
                return profile;
            }
            return null;
        }
    }
}

