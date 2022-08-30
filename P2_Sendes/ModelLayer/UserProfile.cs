using System;
namespace ModelLayer
{
    public class UserProfile
    {
        public Guid ProfileID { get; set; }
        public string Username { get; set; }
        public string? About { get; set; }
        public Guid FK_UserID { get; set; }



        public UserProfile(){}

        /// <summary>
        /// When a user creates a new profile
        /// </summary>
        /// <param name="profile"></param>
        public UserProfile(Guid pID, string pUser, string? pAbout, Guid pUserID)
        {
            this.ProfileID = pID;
            this.Username = pUser;
            this.About = pAbout;
            this.FK_UserID = pUserID;

        }
    }
}

