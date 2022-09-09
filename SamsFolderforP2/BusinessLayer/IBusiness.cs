using ModelsLayer;

namespace BusinessLayer
{
    public interface IBusiness
    {
        Task<LoginDto> LoginAsync(LoginDto loginDto);
        Task<User> NewUserAsync(User newUser);
        Task<List<DisplayDto>> ProductDisplayAsync();
    }
}