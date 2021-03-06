using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
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
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
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
            var model = new LoginViewModel
            {
                TokenId = Guid.NewGuid()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm]LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _userService.LoginAsync(model);
                var user = await _userService.GetUserByEmailAsync(model.Email);
                var jwt = _cache.GetJwt(model.TokenId);
                
                
                return Json(jwt);
            }   
            

            return View(model);
        }
    }
}