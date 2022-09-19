using ModelLayer;

namespace RepoLayer
{
    public interface IADO_ACCESS
    {
        /// <summary>
        /// This gets all the users in the DB
        /// </summary>
        /// <returns></returns>
        Task<List<Models.User>> GetUsersAsync();
        /// <summary>
        /// Registers the user using a Register DTO
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        Task<bool> RegisterUserAsync(REGISTERDTO newUser);
    }
}