using ModelLayer;

namespace BusinessLayer
{
    public interface IUserProfileBL
    {
        Task<dynamic> User_CreateProfile(UserProfileDTO profile);
        Task<List<UserProfile>?> User_GetProfiles(string username);
    }
}