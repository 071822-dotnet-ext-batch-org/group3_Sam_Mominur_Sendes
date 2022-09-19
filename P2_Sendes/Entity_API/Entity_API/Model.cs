using System;
namespace Entity_API
{
    public class Model
    {
        public enum Status
        {
            Guest,User,Admin
        };
        public class User
        {
            public Guid Id { get; set; }
            public string? Username { get; set; }
            public string? Password { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Email { get; set; }
            public Status Role { get; set; }
            public DateTime SignUpDate { get; set; }


            public User() { }
        }
        public Model()
        {
        }
    }
}

