using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PostDriver.Api.Services;

namespace PostDriver.Api.Controllers
{
    public class PostOfficeController : Controller
    {

        private readonly IPostOfficeService _officeService; 
        private readonly IRegionService _regionService;

        public PostOfficeController(IPostOfficeService officeService, IRegionService regionService)
        {
            _officeService = officeService;
            _regionService = regionService;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<JsonResult> GetOfficesAsync()
        {
            var offices = await _officeService.GetOfficesAsync();
            return Json(offices);
        }
    }
}