namespace ModelsLayer
{
    public class User
    {
        public User(Guid userID, string userName, string firsName, string lastName, string password, string email, bool role)
        {
            UserID = userID;
            UserName = userName;
            FirsName = firsName;
            LastName = lastName;
            Password = password;
            Email = email;
            Role = role;
        }

        public Guid UserID { get; set; }
        public string UserName { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Role { get; set; }

    }
}