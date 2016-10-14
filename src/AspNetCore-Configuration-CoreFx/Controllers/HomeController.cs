using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore_MachineConfiguration_CoreFx.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AspNetCore_Configuration_CoreFx.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseConfig _dbOptions;

        public HomeController(IOptions<DatabaseConfig> dbOptions )
        {
            _dbOptions = dbOptions.Value;
        }

        public IActionResult Index()
        {
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
