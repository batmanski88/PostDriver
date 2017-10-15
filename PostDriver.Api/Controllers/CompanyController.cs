using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostDriver.Api.Services;
using PostDriver.Api.ViewModels.CompanyViewModels;

namespace PostDriver.Api.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyService _companyService;
        private readonly IPostOfficeService _officeService;
        private readonly IRegionService _regionService;

        public CompanyController(ICompanyService companyService, IPostOfficeService officeService, IRegionService regionService)
        {
            _companyService  = companyService;
            _officeService = officeService;
            _regionService = regionService;
        }

        [HttpGet]
        public async Task<IActionResult> AddCompany()
        {
            var model = new AddCompanyViewModel();
            await _companyService.ChangeViewModel(model);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(AddCompanyViewModel model)
        {
            if(ModelState.IsValid)
            {
               await _companyService.AddCompanyAsync(model);
            }
            
            return View();
        }

        public async Task<JsonResult> GetOffices()
        {
            var offices =  await _officeService.GetOfficesAsync();
            return Json(offices);
        }

        public async Task<JsonResult> GetRegions(Guid OfficeId)
        {
            var regions = await _regionService.GetRegionsByOfficeIdAsync(OfficeId);
            return Json(regions);
        }
    }
}