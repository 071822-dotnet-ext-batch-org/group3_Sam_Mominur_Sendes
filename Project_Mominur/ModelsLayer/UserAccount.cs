using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class UserAccount
    
    {
           public UserAccount(int user_Id, string user_Name, string first_Name, string last_Name, string user_password, string user_email, bool user_Role)
        {
             
            userId = user_Id;
            userName = user_Name;
            firstName = first_Name;
            lastName = last_Name;
            password = user_password;
            email = user_email;
            userRole = user_Role;

        }


        public int userId { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public bool userRole { get; set; }

    }
}