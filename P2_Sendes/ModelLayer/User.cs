using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModelLayer
{
    public enum Status
    {
        User,
        Admin,
        SuperAdmin
    }
    public class User
    {
        //This is the User class
        //All the data we'll need to SAVE only will be mapped from here
        private Guid pk_EmployeeID {get;set;}
        private string username {get;set;}
        private string password {get;set;}
        private string first {get;set;}
        private string last {get;set;}
        private string email {get;set;}
        private string role {get;set;}
        private DateTime signupDate {get;set;}

        //Getters and Setters of User --- Used to Make properties public to other classes
        public Guid PK_EmployeeID{
            get{
                return pk_EmployeeID;
            }
            set{
                this.pk_EmployeeID = value;
            }
        }
        public string Username{
            get{
                return username;
            }
            set{
                this.username = value;
            }
        }
        public string Password{
            get{
                return password;
            }
            set{
                this.password = value;
            }
        }
        public string First{
            get{
                return first;
            }
            set{
                this.first = value;
            }
        }
        public string Last{
            get{
                return last;
            }
            set{
                this.last = value;
            }
        }

        public string Email{
            get{
                return email;
            }
            set{
                this.email = value;
            }
        }

        public string Role{
            get{
                return role;
            }
            set{
                this.role = value;
            }
        }

        public DateTime SignupDate{
            get{
                return signupDate;
            }
            set{
                this.signupDate = value;
            }
        }

        /// <summary>
        /// This is the method for the default User Constructor
        /// </summary>
        public User()
        {
            this.PK_EmployeeID = Guid.NewGuid();
            this.Username = "User";
            this.Password = "Pass";
            this.First = "Fname";
            this.Last = "Lname";
            this.Email = "example@email.com";
            this.Role = Status.User.ToString();
            this.SignupDate = DateTime.Now;
        }

        //User that gets created
        public User(UserDTO user)
        {
            this.PK_EmployeeID = Guid.NewGuid();
            this.Username = user.Username;
            this.Password = user.Password;
            this.First = user.First;
            this.Last = user.Last;
            this.Email = user.Email;
            this.Role = Status.User.ToString();
            this.SignupDate = DateTime.Now;
        }

        //User that gets loaded from DB
        public User(Guid ID, string username, string password, string firstname, string lastname, string email, int roleBIT_TYPE, DateTime registerDate)
        {
            this.PK_EmployeeID = ID;
            this.Username = username;
            this.Password = password;
            this.First = firstname;
            this.Last = lastname;
            this.Email = email;
            if(roleBIT_TYPE == 0){
                this.Role = Status.User.ToString();

            }else if(roleBIT_TYPE == 1)
            {
                this.Role = Status.Admin.ToString();
            }
            else
            {
                this.Role = Status.SuperAdmin.ToString();
            }
            this.SignupDate = registerDate;
        }
    }
}