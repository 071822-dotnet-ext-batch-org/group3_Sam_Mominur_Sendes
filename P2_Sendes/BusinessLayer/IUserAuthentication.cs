using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLayer;

namespace BusinessLayer
{
    public interface IUserAuthentication
    {
        Task<bool> CheckIf_UserExists(UserDTO user);
        Task<dynamic> User_Register(UserDTO user);
        //Task<UserDTO> User_Login(UserDTO user);

    }
}