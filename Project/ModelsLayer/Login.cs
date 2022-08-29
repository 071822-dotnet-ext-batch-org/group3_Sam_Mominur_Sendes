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
            email = email;
            password = password;
             
        }

        public string email{ get; set; }
        public string password { get; set; }
    }
}