
using System;
using System.Threading.Tasks;
using AutoMapper;
using PostDriver.Api.ViewModels.AccountViewModels;
using PostDriver.Domain.Domain;
using PostDriver.Domain.IRepository;

namespace PostDriver.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;

        public UserService(IUserRepo userRepo, IEncrypter encrypter)
        {
            _userRepo = userRepo;
            _encrypter = encrypter;
        }

        public async Task<UserViewModel> GetUserByIdAsync(Guid UserId)
        {
            var user = await _userRepo.GetUserByIdAsync(UserId);

            return _mapper.Map<User, UserViewModel>(user);
        }

        public async Task LoginAsync(LoginViewModel model)
        {
            var user = await _userRepo.GetUserByEmailAsync(model.Email);

            if(user == null)
            {
                throw new Exception("Użytkownik nie istnieje!");
            }
            var salt = _encrypter.GetSalt(model.Password);
            var hash = _encrypter.GetHash(model.Password, user.Salt);

            if(model.Password == hash)
            {
                return;
            }
        }

        public async Task RegisterAsync(RegisterViewModel model)
        {
            var user = await _userRepo.GetUserByEmailAsync(model.Email);

            if(user != null)
            {
                throw new Exception($"Użytkownik o podanym adresie email: '{model.Email}' już istnieje!");
            }
            
            var salt = _encrypter.GetSalt(model.Password);
            var hash = _encrypter.GetHash(model.Password, salt);

            user = new User(model.Username, model.Email, hash, salt, model.Role);
            await _userRepo.AddUserAsync(user); 
        }
    }
}