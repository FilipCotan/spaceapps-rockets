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
        
        public async Task<IActionResult> Details(int id)
        {
            var launch = await _rocketService.GetLaunchAsync(id);

            return View(launch);
        }
    }
}