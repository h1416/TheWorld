﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using TheWorld.Models;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Wen
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly IConfigurationRoot _config;
        private WorldContext _context;

        public AppController(IMailService mailService, IConfigurationRoot config, WorldContext context)
        {
            _mailService = mailService;
            _config = config;
            _context = context;
        }
        //Home
        public IActionResult Index()
        {
            var data = _context.Trips.ToList();

            return View(data);
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
