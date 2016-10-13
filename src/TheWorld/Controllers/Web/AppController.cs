using Microsoft.AspNetCore.Mvc;

namespace TheWorld.Controllers.Wen
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
