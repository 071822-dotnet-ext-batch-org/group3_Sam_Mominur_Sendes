using System;
namespace ModelLayer
{
    /// <summary>
    /// This is the register DTO (username, password, first, last, email)
    /// </summary>
    public class REGISTERDTO : Models.Guest
    {
        public string? Username { get; set; }
        public string? Password { get; set; }


        public REGISTERDTO(){}
        public REGISTERDTO(string username, string password, string firstname, string lastname, string email): base(firstname, lastname, email)
        {
            this.Username = username;
            this.Password = password;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
        }
    }//END OF REGISTER DTO

    public class LOGINDTO
    {
        public string? Email { get; set; }
        public string? Password { get; set; }

        public LOGINDTO() { }
        public LOGINDTO(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }//END OF LOGIN DTO
}

