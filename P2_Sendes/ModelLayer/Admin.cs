using System;
using System.Xml.Linq;

namespace ModelLayer
{

    public class Admin : UserBase
    {
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
        public Admin() : base(){}
        //public Admin(string fname, string lname, string email, Status role) : base(fname, lname, email, role) {
        //    this.First = fname;
        //    this.Last = lname;
        //    this.Email = email;
        //    this.Role = role;
        //}

        //The arguments passed to the base class are the repeating ones
        public Admin(Guid ID, string username, string password, string fname, string lname, string email, Status role, DateTime registerDate) : base(fname, lname, email)
        {
            this.PK_UserID = ID;
            this.Username = username;
            this.Password = password;
            this.First = fname;
            this.Last = lname;
            this.Email = email;
            this.Role = Status.Admin;
            this.SignupDate = registerDate;

        }
    }
}

