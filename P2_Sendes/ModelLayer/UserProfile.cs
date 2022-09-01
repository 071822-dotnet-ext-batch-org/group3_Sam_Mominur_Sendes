using System;
namespace ModelLayer
{
    public class UserProfile
    {
        public Guid ProfileID { get; set; }
        public string Username { get; set; }
        public string? About { get; set; }



        /// <summary>
        /// When a user creates a new profile
        /// </summary>
        /// <param name="pID"></param>
        /// <param name="pUser"></param>
        /// <param name="pAbout"></param>
        public UserProfile(Guid pID, string pUser, string? pAbout)
        {
            this.ProfileID = pID;
            this.Username = pUser;
            this.About = pAbout;

        }
    }
}

