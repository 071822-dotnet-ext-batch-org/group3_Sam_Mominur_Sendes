using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class UserAccount
    
    {
           public UserAccount(Guid user_Id, string user_Name, string first_Name, string last_Name, string user_password, string user_email, bool user_Role)
        {
             
            UserID = user_Id;
            UserName = user_Name;
            FirstName = first_Name;
            LastName = last_Name;
            Password = user_password;
            Email = user_email;
            Role = user_Role;

        }


        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Role { get; set; }

    }
}