using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHome.Data.Services;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Controllers
{
    public class HomeController : Controller
    {
     
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Members()
        {
            return View();
        }
        public IActionResult HomeRooms()
        {
            return View();
        }
        public IActionResult DashBoard()
        {
            return View();
        }

    }
}
