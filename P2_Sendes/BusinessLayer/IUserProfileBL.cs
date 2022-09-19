using ModelLayer;

namespace BusinessLayer
{
    public interface IUserProfileBL
    {
        Task<UserProfile?> User_CreateProfile(UserProfileDTO profile);
        Task<List<UserProfile>?> User_GetProfiles();
        Task<bool> User_EditProfile(UserProfileDTO profileDTO);
    }
}