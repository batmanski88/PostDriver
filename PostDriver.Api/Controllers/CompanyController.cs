using Microsoft.AspNetCore.Mvc;

namespace PostDriver.Api.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult AddCompany()
        {
            return View();
        }
    }
}