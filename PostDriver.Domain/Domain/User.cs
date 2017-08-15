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

        protected User()
        {
            
        }
        public User(Guid userId, string userName, string email, string password, string salt, string role)
        {
            UserId = userId;
            SetUserName(userName);
            SetEmail(email);
            SetPassword(password, salt);
            SetRole(role);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetUserName(string userName)
        {
            UserName = userName;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            Email = email;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, string salt)
        {
            Password = password;
            Salt = salt;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetFullName(string fullName)
        {
            FullName = fullName;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetRole(string role)
        {
            Role = role;
            UpdatedAt = DateTime.UtcNow;

        }
    }
}