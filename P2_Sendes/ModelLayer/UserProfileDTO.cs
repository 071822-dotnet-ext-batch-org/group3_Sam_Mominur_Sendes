using System;
namespace ModelLayer
{
    public class UserProfileDTO
    {
        public string Username { get; set; }
        public string? About { get; set; }



        public UserProfileDTO() { }

        /// <summary>
        /// When a user creates a new profile
        /// </summary>
        /// <param name="profile"></param>
        public UserProfileDTO(string pUser, string? pAbout)
        {
            this.Username = pUser;
            this.About = pAbout;

        }
    }
}

