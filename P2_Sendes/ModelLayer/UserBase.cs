using System;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace ModelLayer
{
    public enum Status
    {
        Guest,
        User,
        Admin
    }

    public class UserBase
    {
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Your first name must be within 3-30 characters")]
        [Required(ErrorMessage = "I'm sure you're named something...")]
        public string First { get; set; } = string.Empty;

        [Required(ErrorMessage = "I'm sure you're named something...")]
        [StringLength(30, MinimumLength =3,ErrorMessage= "Your last name must be within 3-30 characters")]
        public string Last { get; set; } = string.Empty;

        [StringLength(30, MinimumLength = 5, ErrorMessage = "Your last name must be within 5-30 characters")]
        [Required(ErrorMessage = "An email is required!!!")]
        public string Email { get; set; } = string.Empty;

        //[Required(ErrorMessage = "An email is required!!!")]
        public Status Role { get; set; } = Status.Guest;

        public UserBase() {
            this.First = string.Empty;
            this.Last = string.Empty;
            this.Email = string.Empty;
            //this.Role = Status.Guest;
        }
        public UserBase(string firstname, string lastname, string email)
        {
            this.First = firstname;
            this.Last = lastname;
            this.Email = email;
            //this.Role = Status.Guest;
        }
    }
}

