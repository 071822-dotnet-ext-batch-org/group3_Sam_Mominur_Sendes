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
        Task<dynamic> User_Register(UserRegisterDTO user);
        Task<dynamic> User_Login(string username, string password);

    }
}