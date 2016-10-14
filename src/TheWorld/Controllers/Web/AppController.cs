using Microsoft.AspNetCore.Mvc;

namespace TheWorld.Controllers.Wen
{
    public class AppController : Controller
    {
        //Home
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
