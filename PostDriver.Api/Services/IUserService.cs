using System;
using System.Threading.Tasks;
using PostDriver.Api.ViewModels.AccountViewModels;

namespace PostDriver.Api.Services
{
    public interface IUserService
    {
        Task<UserViewModel> GetUserByIdAsync(Guid UserId);
        
        Task RegisterAsync(RegisterViewModel model);

        Task LoginAsync(LoginViewModel model);
    }

}