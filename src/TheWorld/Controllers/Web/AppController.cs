using Microsoft.AspNetCore.Mvc;
using System;
using TheWorld.ViewModels;

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
            //throw new InvalidOperationException("bad thing happened");
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel vmContact)
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
