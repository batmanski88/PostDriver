using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostDriver.Api.Services;

namespace PostDriver.Api.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CompanyService _companyService;

        public CompanyController(CompanyService companyService)
        {
            _companyService  = companyService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult AddCompany()
        {
            return View();
        }
    }
}