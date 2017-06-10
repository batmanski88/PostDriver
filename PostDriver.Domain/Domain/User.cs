using System;

namespace PostDriver.Domain.Domain
{
    public class User
    {
        public Guid UserId {get; protected set;}
        public string UserName {get; protected set;}
        public string Email {get; protected set;}
        public string Password {get; protected set;}
        public string Salt {get; protected set;}
        public string FullName {get; protected set;}
        public string Role {get; protected set;}
        public DateTime CreatedAt {get; protected set;}
        public DateTime UpdatedAt {get; protected set;}

        public User(string userName, string email, string password, string salt, string role)
        {
            UserId = Guid.NewGuid();
            UserName = userName;
            Email = email;
            Password = password;
            Salt = salt;
            Role = role;
        }
    }
}