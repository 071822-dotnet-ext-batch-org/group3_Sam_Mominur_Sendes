using System;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class UserProfileDTO
    {
        [Required(ErrorMessage = "You must have an existing username to create a profile...")]
        public string Username { get; set; }
        [StringLength(150, MinimumLength = 0, ErrorMessage = "Your response must be between 0 and 150 characters")]
        public string? About { get; set; }



        /// <summary>
        /// When a user creates a new profile
        /// </summary>
        /// <param name="pUser"></param>
        /// <param name="pAbout"></param>
        public UserProfileDTO(string pUser, string? pAbout)
        {
            this.Username = pUser;
            this.About = pAbout;

        }
    }
}