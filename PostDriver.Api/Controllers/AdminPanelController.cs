using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostDriver.Api.Services;
using PostDriver.Api.ViewModels.PostOfficeViewModels;
using PostDriver.Api.ViewModels.RegionViewModels;

namespace PostDriver.Api.Controllers
{
    public class AdminPanelController : Controller
    {

        private readonly IPostOfficeService _officeService;
        private readonly IRegionService _regionService;
        
        public AdminPanelController(IPostOfficeService officeService, IRegionService regionService )
        {
            _officeService = officeService;
            _regionService = regionService;
        }

        //Adding PostOffices
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

        //Adding Regions
        [HttpGet]
        public IActionResult AddRegion()
        {
            return View();
        }
    
        [HttpPost]
        public async Task<IActionResult> AddRegion([FromForm]RegionViewModel model)
        {
            if(ModelState.IsValid)
            {
                await _regionService.AddRegionAsync(model);
            }   

            return View();
        }

    }
}