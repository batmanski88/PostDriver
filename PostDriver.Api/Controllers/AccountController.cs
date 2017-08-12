using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PostDriver.Api.Infrastructure.Extensions;
using PostDriver.Api.Services;
using PostDriver.Api.ViewModels.AccountViewModels;

namespace PostDriver.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMemoryCache _cache;

        public AccountController(IUserService userService, IMemoryCache cache)
        {
            _userService = userService;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _userService.RegisterAsync(model);
            }

            ModelState.Clear();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _userService.LoginAsync(model);

                var tokenId = Guid.NewGuid();
                var user = await _userService.GetUserByEmailAsync(model.Email);
                _cache.GetJwt(tokenId);
                
            }   

            return View();
        }
    }
}