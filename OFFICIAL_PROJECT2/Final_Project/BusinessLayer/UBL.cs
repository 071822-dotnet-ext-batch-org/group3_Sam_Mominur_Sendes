using ModelLayer;
using RepoLayer;
namespace BusinessLayer;
public class User_BusinessLayer : IUser_BusinessLayer
{
    private IADO_ACCESS _repo;
    public User_BusinessLayer(IADO_ACCESS aDO)
    {
        this._repo = aDO;
    }

    /// <summary>
    /// This gets all the users in the DB using repo
    /// </summary>
    /// <returns></returns>
    public async Task<List<Models.User>> GetUsers()
    {
        List<Models.User> users = await this._repo.GetUsersAsync();
        return users;
    }//END OF GET ALL USERS

    /// <summary>
    /// This registers a new user using repo and sends back the created user
    /// </summary>
    /// <param name="newUser"></param>
    /// <returns></returns>
    public async Task<Models.User?> RegisterUser(REGISTERDTO newUser)
    {
        bool registeredUser = await this._repo.RegisterUserAsync(newUser);
        if (registeredUser == true)
        {
            List<Models.User> users = await this._repo.GetUsersAsync();
            Models.User? createdUser = users.Find(user => user.Email == newUser.Email);
            return createdUser;
        }
        else
        {
            return null;
        }
    }//END OF REGISTER USER

}
