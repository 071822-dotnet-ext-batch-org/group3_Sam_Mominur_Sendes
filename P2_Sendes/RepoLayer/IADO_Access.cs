using ModelLayer;

namespace RepoLayer
{
    public interface IADO_Access
    {
        Task<bool> Register_User(User user);
        Task<bool> CheckFor_User(User user);
    }
}