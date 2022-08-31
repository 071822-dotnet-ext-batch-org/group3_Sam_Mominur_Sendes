using ModelLayer;

namespace RepoLayer
{
    public interface IADO_Access
    {
        Task<bool> Register_User(User user);
        Task<User?> Login_User(string username, string password);
        Task<bool> CheckFor_User(User user);
        Task<User?> Get_User(string username);
        Task<bool> Create_UserProfile(UserProfile profile);
        //Task<UserProfile?> Get_UserProfile(string username);
        Task<List<UserProfile>?> Get_UserProfiles();
    }
}