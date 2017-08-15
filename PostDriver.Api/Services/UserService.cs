
using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using PostDriver.Api.Infrastructure.Extensions;
using PostDriver.Api.ViewModels.AccountViewModels;
using PostDriver.Domain.Domain;
using PostDriver.Domain.IRepository;

namespace PostDriver.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;

        public UserService(IUserRepo userRepo, IEncrypter encrypter, IJwtHandler jwtHandler,IMemoryCache cache, IMapper mapper)
        {
            _userRepo = userRepo;
            _encrypter = encrypter;
            _jwtHandler = jwtHandler;
            _cache = cache;
            _mapper = mapper;
        }

        public async Task<UserViewModel> GetUserByEmailAsync(string Email)
        {
            var user = await _userRepo.GetUserByEmailAsync(Email);

            return _mapper.Map<User, UserViewModel>(user);
        }

        public async Task LoginAsync(LoginViewModel model)
        {
            var user = await _userRepo.GetUserByEmailAsync(model.Email);

            if(user == null)
            {
                throw new Exception("Użytkownik nie istnieje!");
            }
            
            var token = _jwtHandler.CreateToken(user.UserId, user.Role);
            _cache.SetJwt(token);

            var hash = _encrypter.GetHash(model.Password, user.Salt);

            if(user.Password == hash)
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

            var role = "user";
            
            var salt = _encrypter.GetSalt(model.Password);
            var hash = _encrypter.GetHash(model.Password, salt);

            user = new User(Guid.NewGuid(), model.Username, model.Email, hash, salt, role);
            await _userRepo.AddUserAsync(user); 
        }
    }
}