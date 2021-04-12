using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TwitterApi.Controllers.Twitter;
using TwitterApi.Models;

namespace TwitterApi.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly AppSettings _appSettings;

        public HomeController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult More()
        {
            return View();
        }

        public ActionResult TwitterHome(string twitterUserName = "BBC")
        {
            var model = TwitterFeeds.GetTwitterFeeds( _appSettings.ConsumerKey, _appSettings.ConsumerSecret, twitterUserName);

            return View(model);
        }

        public PartialViewResult AddTwitterModal()
        {
            return PartialView("_AddTwitterModal");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
