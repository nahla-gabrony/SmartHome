using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartHome.Data.Services;
using SmartHome.Data.ViewModels.Account;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Controllers
{
    public class MemberController : Controller
    {

        private readonly IUserService _userService;

        public MemberController(IUserService userService)
        {
            _userService = userService;
        }

        
        [Route("Members")]
        public async Task<IActionResult> Members()
        {
            var data = await _userService.GetHomeUserHistory();
            return View(data);
        }

        [Route("ManageUsers")]
        public async Task<IActionResult> ManageUsers()
        {
            dynamic Model = new ExpandoObject();
            Model.userApp = await _userService.GetAppUsers();
            Model.userHome = await _userService.GetHomeUsers();
            return View(Model);
        }

    }
}
