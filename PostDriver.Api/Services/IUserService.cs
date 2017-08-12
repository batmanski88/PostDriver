using System;
using System.Threading.Tasks;
using PostDriver.Api.ViewModels.AccountViewModels;

namespace PostDriver.Api.Services
{
    public interface IUserService : IService
    {
        Task<UserViewModel> GetUserByEmailAsync(string Email);
        
        Task RegisterAsync(RegisterViewModel model);

        Task LoginAsync(LoginViewModel model);
    }

}