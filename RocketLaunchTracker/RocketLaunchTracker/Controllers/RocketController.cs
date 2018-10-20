using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RocketLaunchTracker.Services;

namespace RocketLaunchTracker.Controllers
{
    public class RocketController : Controller
    {
        private readonly RocketLaunchService _rocketService;

        public RocketController(RocketLaunchService rocketService)
        {
            _rocketService = rocketService;
        }

        public async Task<IActionResult> Details()
        {
            var launch = await _rocketService.GetLaunchAsync(1636);

            return View(launch);
        }
    }
}