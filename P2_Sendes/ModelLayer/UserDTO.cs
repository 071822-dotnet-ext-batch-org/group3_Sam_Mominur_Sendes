using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class UserDTO
    {
        // public Guid PK_EmployeeID {get;set;}
        [Required(ErrorMessage = "Your username is required!!!")]//This tag gives front-end form element a required message if something isnt filled
        public string Username {get;set;}
        [Required(ErrorMessage = "A password must be provided!!!")]
        public string Password {get;set;}
        public string? First {get;set;}
        public string? Last {get;set;}
        [Required(ErrorMessage = "An email must be provided!!!")]
        public string Email {get;set;}
        // public string Role {get;set;}
        // public DateTime SignupDate {get;set;}
        // public DateTime LastSignInDate {get;set;}


        /// <summary>
        /// Default User DTO
        /// </summary>
        public UserDTO(){
            this.Username = "User";
            this.Password = "Pass";
            this.First = "Fname";
            this.Last = "Lname";
            this.Email = "example@email.com";
        }

        /// <summary>
        /// This is the DTO
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="email"></param>
        public UserDTO(string username, string password, string firstname, string lastname, string email){
            this.Username = username;
            this.Password = password;
            this.First = firstname;
            this.Last = lastname;
            this.Email = email;
        }

        /// <summary>
        /// A loaded or auto-populated User DTO
        /// </summary>
        /// <param name="user"></param>
        public UserDTO(User user){
            // this.PK_EmployeeID = user.PK_EmployeeID;
            this.Username = user.Username;
            this.Password = user.Password;
            this.First = user.First;
            this.Last = user.Last;
            this.Email = user.Email;
            // this.Role = user.Role;
            // this.SignupDate = user.SignupDate;
        }

    }
}