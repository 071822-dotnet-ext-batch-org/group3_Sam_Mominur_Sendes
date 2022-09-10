﻿using System;
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

        /// <summary>
        /// This method creates a User profile
        /// --Returns a dynamic (UserProfileDTO, false, or error message)
        /// --False
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
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


            UserProfile newUserProfile = new UserProfile(Guid.NewGuid(), profile.Username, profile.About);
            UserProfileDTO? verifiedResult = await _repoLayer.Create_UserProfile(newUserProfile);
            if (verifiedResult != null)//If the user was saved
            {//return true
                return verifiedResult;
            }

            return false;//If user was not saved returrn false


        }

        public async Task<List<UserProfile>?> User_GetProfiles()
        {
            //List<UserProfile> pList = new List<UserProfileDTO>();
            List<UserProfile>? loadedProfileList = await this._repoLayer.Get_UserProfiles();
            //if (loadedProfileList != null)//If the username matched and the Profile was gotten
            //{
            //    foreach(UserProfile p in loadedProfileList)
            //    {
            //        UserProfileDTO? profile = new UserProfileDTO(p.Username, p.About);
            //        pList.Add(profile);

            //    }
            //    return pList;
            //}
            return loadedProfileList;
        }
    }
}