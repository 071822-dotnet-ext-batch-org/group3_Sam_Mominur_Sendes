using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class Login
    {
          public Login(string email, string password)
        {
            Email = email;
            Password = password;

        }

        public string Email { get; set; }
        public string Password { get; set; }
    }
    
}