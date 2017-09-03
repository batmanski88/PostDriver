using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostDriver.Api.Services;
using PostDriver.Api.ViewModels.PostOfficeViewModel;

namespace PostDriver.Api.Controllers
{
    public class AdminPanelController : Controller
    {

        private readonly IPostOfficeService _officeService;
        
        public AdminPanelController(IPostOfficeService officeService)
        {
            _officeService = officeService;
        }

        [HttpGet]
        public async Task<IActionResult> AddPostOffice()
        {
            return View();
        }

        public async Task<IActionResult> AddPostOffice([FromForm]AddPostOfficeViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _officeService.AddOfficeAsync(model);
            }
            
            return View();
        }
    }
}