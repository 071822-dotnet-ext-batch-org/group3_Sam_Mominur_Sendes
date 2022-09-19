using ModelLayer;

namespace BusinessLayer
{
    public interface IUser_BusinessLayer
    {
        /// <summary>
        /// This gets all the users in the DB using repo
        /// </summary>
        /// <returns></returns>
        Task<List<Models.User>> GetUsers();
        /// <summary>
        /// This registers a new user using repo and sends back the created user
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        Task<Models.User?> RegisterUser(REGISTERDTO newUser);
    }
}