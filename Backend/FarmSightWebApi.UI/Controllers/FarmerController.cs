using Microsoft.AspNetCore.Mvc;

namespace FarmSightWebApi.UI.Controllers
{
    public class FarmerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
