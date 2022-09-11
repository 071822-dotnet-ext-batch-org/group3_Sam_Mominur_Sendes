using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLayer;

namespace BusinessLayer
{
    public interface IUserAuthentication
    {
        Task<bool> CheckIf_UserExists(string username);
        Task<bool> CheckIf_UserExists_W_USERNAME(string Username);
        Task<User?> User_Register(UserRegisterDTO user);
        Task<dynamic?> User_Login(UserLoginDTO user);
        Task<dynamic?> GET_USER_BY_USERNAME(string Username);

    }
}