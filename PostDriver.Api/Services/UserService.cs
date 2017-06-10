
using System;
using System.Threading.Tasks;
using PostDriver.Api.ViewModels.AccountViewModels;
using PostDriver.Domain.Domain;
using PostDriver.Domain.IRepository;

namespace PostDriver.Api.Services
{
    public class UserService : IUserService
    {
         private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<UserViewModel> GetUserByIdAsync(Guid UserId)
        {
            var user = await _userRepo.GetUserByIdAsync(UserId);

            UserViewModel viewModel = new UserViewModel
            {
                Username = user.UserName,
                FullName = user.FullName,
                Role = user.Role,
            }; 

            return viewModel;
        }

        public async Task LoginAsync(LoginViewModel model)
        {
            var user = await _userRepo.GetUserByEmailAsync(model.Email);

            if(user == null)
            {
                throw new Exception("Użytkownik nie istnieje!");
            }
        }

        public async Task RegisterAsync(RegisterViewModel model)
        {
            var user = await _userRepo.GetUserByEmailAsync(model.Email);

            if(user != null)
            {
                throw new Exception($"Użytkownik o podanym adresie email: '{model.Email}' już istnieje!");
            }
            else
            {
                user = new User(model.Email, model.Password, model.ConfirmPassword, model.Username, model.Role);
            }
            
            await _userRepo.AddUserAsync(user); 
    }
}