using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class UserAccount
    
    {
           public Product(int userId, string userName, string firstName, string lastName, string password, string email, bool userRole)
        {
             
            userId = userId;
            userName = userName;
            firstName = firstName;
            lastName = lastName;
            password = password;
            email = email;
            userRole = userRole;

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