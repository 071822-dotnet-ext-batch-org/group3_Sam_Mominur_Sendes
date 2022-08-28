using ModelLayer;

namespace RepoLayer
{
    public interface IADO_Access
    {
        Task<dynamic> Register_User(User user);
    }
}