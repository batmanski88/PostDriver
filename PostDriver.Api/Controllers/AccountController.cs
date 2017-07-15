using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PostDriver.Api.Services;
using PostDriver.Api.ViewModels.AccountViewModels;

namespace PostDriver.Api.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        { 
            var model = new RegisterViewModel();

            return View(model);
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
            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _userService.LoginAsync(model);
            }

            return RedirectToAction("Index", "HomeController");
        }
    }
}