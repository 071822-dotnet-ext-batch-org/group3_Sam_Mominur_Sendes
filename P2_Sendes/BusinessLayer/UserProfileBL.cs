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

        /// <summary>
        /// This method creates a User profile
        /// --Returns a dynamic (UserProfileDTO, false, or error message)
        /// --False
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public async Task<UserProfile?> User_CreateProfile(UserProfileDTO profile)
        {
            UserProfile newUserProfile = new UserProfile(Guid.NewGuid(), profile.Username, profile.About);
            UserProfile? verifiedResult = await _repoLayer.Create_UserProfile(newUserProfile);
            if (verifiedResult != null)//If the user was saved
            {//return true
                return verifiedResult;
            }
            else
            {
                return null;//If user was not saved returrn false

            }



        }

        public async Task<List<UserProfile>?> User_GetProfiles()
        {
            List<UserProfile>? loadedProfileList = await this._repoLayer.Get_UserProfiles();
            return loadedProfileList;
        }

        public async Task<bool> User_EditProfile(UserProfileDTO profileDTO)
        {

            bool editted = await this._repoLayer.Edit_UserProfile(profileDTO);
            if(editted == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
