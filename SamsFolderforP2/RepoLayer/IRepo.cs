using ModelsLayer;

namespace RepoLayer
{
    public interface IRepo
    {
        Task<LoginDto> LoginAsync(LoginDto login);
        Task<User> NewUserAsync(User newUser);
        Task<List<DisplayDto>> ProductDisplayAsync();
    }
}