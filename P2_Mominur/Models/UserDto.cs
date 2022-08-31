using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserDto
    {


        public UserDto(string username, string firstName, string lastName, string password, string email, bool role)
        {
            UserName = username;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
            Role = role;

        }

        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Role { get; set; }

    }

}
