using Microsoft.AspNetCore.Mvc;
using System;

namespace TheWorld.Controllers.Wen
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            throw new InvalidOperationException("bad thing happened");
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
