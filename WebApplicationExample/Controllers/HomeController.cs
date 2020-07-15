using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PSC.reCAPTCHA;
using WebApplicationExample.Models;

namespace WebApplicationExample.Controllers
{
    public class HomeController : Controller
    {
        private string reCAPTCHAPublicKey = "<here your public key>";
        private string reCAPTCHASecretKey = "<here your secret key>";

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.ClientSecret = reCAPTCHAPublicKey;
            return View();
        }

        [HttpPost]
        public IActionResult Index(string recaptcha)
        {
            if (new reCAPTCHA().IsReCaptchaValid(recaptcha, reCAPTCHASecretKey))
                return View("~/Views/Home/Success.cshtml");
            else
                return View("~/Views/Home/Failed.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
