using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace ModelLayer
{

    public class User : UserBase
    {
        //This is the User class
        //All the data we'll need to SAVE only will be mapped from here
        private Guid pk_UserID { get; set; }
        private string username { get; set; } = string.Empty;
        private string password { get; set; } = string.Empty;
        //private string? role { get; set; }
        private DateTime signupDate { get; set; }

        //Getters and Setters of User --- Used to Make properties public to other classes
        public Guid PK_UserID
        {
            get
            {
                return pk_UserID;
            }
            set
            {
                this.pk_UserID = value;
            }
        }
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                this.username = value;
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                this.password = value;
            }
        }
        //public string? Role
        //{
        //    get
        //    {
        //        return role;
        //    }
        //    set
        //    {
        //        this.role = value;
        //    }
        //}
        public DateTime SignupDate
        {
            get
            {
                return signupDate;
            }
            set
            {
                this.signupDate = value;
            }
        }
        public User() : base() { }
        //public User(string fname, string lname, string email, Status role) : base(fname, lname, email, role)
        //{
        //    this.First = fname;
        //    this.Last = lname;
        //    this.Email = email;
        //    this.Role = role;
        //}
        //User that gets loaded from DB
        public User(Guid ID, string username, string password, string fname, string lname, string email, Status role, DateTime registerDate) : base(fname, lname, email)
        {
            this.PK_UserID = ID;
            this.Username = username;
            this.Password = password;
            this.First = fname;
            this.Last = lname;
            this.Email = email;
            this.Role = Status.User;
            this.SignupDate = registerDate;
        }
    }
}