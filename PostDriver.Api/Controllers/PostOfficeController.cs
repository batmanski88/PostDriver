using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostDriver.Api.Services;

namespace PostDriver.Api.Controllers
{
    public class PostOfficeController : Controller
    {

        private readonly IPostOfficeService _officeService; 

        public PostOfficeController(IPostOfficeService officeService)
        {
            _officeService = officeService;
        }
        public async Task<IActionResult> GetOfficesAsync()
        {
            var ofiices = await _officeService.GetOfficesAsync();
            return View(ofiices);
        }
    }
}