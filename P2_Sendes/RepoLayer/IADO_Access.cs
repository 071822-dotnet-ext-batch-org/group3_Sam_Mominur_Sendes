using ModelLayer;

namespace RepoLayer
{
    public interface IADO_Access
    {
        Task<bool> Register_User(dynamic user);
        Task<dynamic?> Login_User(string username, string password);
        Task<bool> CheckFor_User(string username);
        Task<dynamic?> Get_User(string username);
        Task<UserProfileDTO?> Create_UserProfile(UserProfile profile);
        Task<List<UserProfile>?> Get_UserProfiles();
    }
}