using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_Mvc_Insights_CoreFx.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            TelemetryClient client = new TelemetryClient();

            client.TrackTrace("test");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
