using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using TheWorld.Models;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Wen
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IConfigurationRoot _config;
        private IWorldRepository _repository;
        private ILogger<AppController> _logger;

        public AppController(IMailService mailService,
            IConfigurationRoot config,
            IWorldRepository repository,
            ILogger<AppController> logger)
        {
            _mailService = mailService;
            _config = config;
            _repository = repository;
            _logger = logger;
        }
        //Home
        public IActionResult Index()
        {
            try
            {
                var data = _repository.GetAllTrips();

                return View(data);
            }
            catch(Exception ex)
            {
                // log error 
                _logger.LogError($"Failed to get trips in homepage: {ex.Message}");

                // redirect to user
                return Redirect("/error");
            }

        }

        public IActionResult Contact()
        {
            //throw new InvalidOperationException("bad thing happened");
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel vmContact)
        {
            if (vmContact.Email.IndexOf('.') == -1)
            {
                ModelState.AddModelError("", "Email must contain one period.");
            }

            if (ModelState.IsValid)
            {
                // Send email
                _mailService.SendMail(_config["MailSettings:ToAddress"], vmContact.Email, _config["MailSettings:Subject"], vmContact.Message);

                // Clear all values so that the email will not accidently sent once more
                ModelState.Clear();

                // Set the message notify user that email has been sent successfully
                ViewBag.UserMessage = "Message Sent Successfully";
            }
            
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
