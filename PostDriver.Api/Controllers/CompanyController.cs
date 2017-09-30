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

        public CompanyController(ICompanyService companyService)
        {
            _companyService  = companyService;
        }

        [HttpGet]
        public IActionResult AddCompany()
        {
            return View();
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
    }
}