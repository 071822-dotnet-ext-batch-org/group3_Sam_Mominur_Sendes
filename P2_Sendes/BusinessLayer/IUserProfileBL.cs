using ModelLayer;

namespace BusinessLayer
{
    public interface IUserProfileBL
    {
        Task<dynamic> User_CreateProfile(UserProfileDTO profile);
        Task<UserProfileDTO?> User_GetProfile(string username);
    }
}