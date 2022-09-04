
using ModelLayer;

namespace RepoLayer
{
    public interface IADO_Access
    {
        Task<dynamic?> Register_User(dynamic user);
        Task<dynamic?> Login_User(UserLoginDTO user);
        Task<bool> CheckFor_User(string username);
        Task<dynamic?> Get_User(string username);
        Task<UserProfileDTO?> Create_UserProfile(UserProfile profile);
        Task<List<UserProfile>?> Get_UserProfiles();
        Task<List<Product>?> Get_Products();
        Task<bool> Add_Product(Product product);
    }
}