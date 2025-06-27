using Microsoft.AspNetCore.Mvc;

namespace FarmSightWebApi.UI.Controllers
{
    public class CropCalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
