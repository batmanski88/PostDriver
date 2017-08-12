using System;

namespace PostDriver.Api.ViewModels.AccountViewModels
{
    public class UserViewModel
    {
        public Guid UserId {get; set;}
        public string UserName {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public string Salt {get; set;}
        public string FullName {get; set;}
        public string Role {get; set;}
    }
}