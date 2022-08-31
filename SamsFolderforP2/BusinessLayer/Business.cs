using ModelsLayer;
using RepoLayer;
using System.Net.Sockets;

namespace BusinessLayer
{
    public class Business
    {
        private readonly Repo _repoLayer;
        public Business()
        {
            this._repoLayer = new Repo();
        }


        /// <summary>
        /// #1 Login
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        public async Task<LoginDto> LoginAsync(LoginDto loginDto)
        {
            LoginDto list = await this._repoLayer.LoginAsync(loginDto);
            return loginDto;
        }

        /// <summary>
        /// #2 Register a new account
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public async Task<User> NewUserAsync(User newUser)
        {
            User user = await this._repoLayer.NewUserAsync(newUser);
            return user;
        }
        
       
        /// <summary>
        /// #3 Display products
        /// </summary>
        /// <returns></returns>
        public async Task<List<DisplayDto>> ProductDisplayAsync()
        {
            List<DisplayDto> list = await this._repoLayer.ProductDisplayAsync();
            return list;
        }
    }
}