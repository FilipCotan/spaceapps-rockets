using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RocketLaunchTracker.Models;
using RocketLaunchTracker.Services;

namespace RocketLaunchTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly RocketLaunchService _rocketService;

        public HomeController(RocketLaunchService rocketService)
        {
            _rocketService = rocketService;
        }

        public async Task<IActionResult> Index()
        {
            var launchInfo = await _rocketService.GetNextLaunchesAsync(5);

            return View(launchInfo);
        }

        public async Task<IActionResult> List()
        {
            var launchInfo = await _rocketService.GetNextLaunchesAsync(5);

            return View(launchInfo);
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
