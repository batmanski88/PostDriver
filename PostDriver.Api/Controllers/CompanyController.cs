using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PostDriver.Api.Controllers
{
    public class CompanyController : Controller
    {
        [Authorize]
        public IActionResult AddCompany()
        {
            return View();
        }
    }
}