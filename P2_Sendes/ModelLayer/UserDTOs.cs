using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ModelLayer
{

    //----------------------------------------------------Login Section----------------------
    public class UserLoginDTO
    {
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Your username must be within 3-30 characters")]
        [Required(ErrorMessage = "Your email is required!!!")]//This tag gives front-end form element a required message if something isnt filled
        public string Email { get; set; } = string.Empty;

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Your password must be within 5-50 characters")]
        [Required(ErrorMessage = "A password must be provided!!!")]
        public string Password { get; set; } = string.Empty;

        // public string Role {get;set;}
        // public DateTime SignupDate {get;set;}
        // public DateTime LastSignInDate {get;set;}
        public UserLoginDTO() { }
        public UserLoginDTO(string Email, string password)
        {
            this.Email = Email;
            this.Password = password;
        }

    }//End of Login DTO




    //----------------------------------------------------Register Section----------------------
    public class UserRegisterDTO : UserBase
    {
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Your username must be within 3-30 characters")]
        [Required(ErrorMessage = "Your username is required!!!")]//This tag gives front-end form element a required message if something isnt filled
        private string username { get; set; } = string.Empty;

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Your password must be within 5-50 characters")]
        [Required(ErrorMessage = "A password must be provided!!!")]
        private string password { get; set; } = string.Empty;

        // public string Role {get;set;}
        // public DateTime SignupDate {get;set;}
        // public DateTime LastSignInDate {get;set;}

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


        public UserRegisterDTO() : base() { }


        /// <summary>
        /// This is the User DTO
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public UserRegisterDTO(string username, string password, string firstname, string lastname, string email) : base(firstname, lastname, email)
        {
            this.Username = username;
            this.Password = password;
            this.First = firstname;
            this.Last = lastname;
            this.Email = email;
        }


    }
}