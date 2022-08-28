using ModelsLayer;
using RepoLayer;

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

    }
}