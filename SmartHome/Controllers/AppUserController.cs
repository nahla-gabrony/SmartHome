using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Data.Services;
using SmartHome.Data.ViewModels.Account;
using SmartHome.Data.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Controllers
{
    [Authorize]
    public class AppUserController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public AppUserController(IAccountService accountService,
                                 IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        [Route("User/Profile-Details")]
        public async Task<IActionResult> ProfileDetails()
        {
            var user = await _userService.GetAppUserDetails();
            var data = await _userService.GetHomeUserByEmail(user.Email);
            return View(data);
        }

        [Route("User/Profile-Edit/{id:int:min(1)}")]
        public async Task<IActionResult> ProfileEdit(int id)
        {
            var data = await _userService.GetAppUserById(id);
            if(data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }

        [Route("User/Profile-Edit/{id:int:min(1)}")]
        [HttpPost]
        public async Task<IActionResult> ProfileEdit(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UpdateAppUser(model, "images/profile/");
                await _userService.UpdateHomeUser(model, "images/profile/");
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                } 
            }
            return RedirectToAction("ProfileDetails");
        }

        [Authorize(Roles = "Control Users")]
        [Route("Members/Edit-User/{id:int:min(1)}")]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _userService.GetAppUserById(id);
            if (data == null)
            {
                return View("NotFound");
            }
         
            ViewBag.EditUserRoleSuccess = TempData["EditUserRoleSuccess"];
            return View(data);
        }

        [Authorize(Roles = "Control Users")]
        [Route("Members/Edit-User/{id:int:min(1)}")]
        [HttpPost]
        public async Task<IActionResult> Edit(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserType == 1)
                {
                    await _userService.UpdateHomeUser(model, "images/profile/");
                    // delete Appuser
                    var Appuser = await _accountService.GetUserByEmail(model.Email);
                    if (Appuser == null)
                    {
                        return View("NotFound");
                    }

                    else
                    {
                        var result = await _userService.DeleteAppUser(Appuser);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("ManageUsers", "HomeUser");
                        }

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return RedirectToAction("ManageUsers", "HomeUser");
                    }
                }

                if (model.UserType == 2)
                {
                    var result = await _userService.UpdateAppUser(model, "images/profile/");
                    await _userService.UpdateHomeUser(model, "images/profile/");
                    if (!result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        return View(model);
                    }
                }
            }
            return RedirectToAction("ManageUsers" , "HomeUser");
        }

        [Authorize(Roles = "Control Users")]
        public async Task<IActionResult> Delete(int id)
        {
            var homeUser = await _userService.GetAppUserById(id);
            if (homeUser == null)
            {
                return View("NotFound");
            }

            var Appuser = await _accountService.GetUserByEmail(homeUser.Email);
            if (Appuser == null)
            {
                return View("NotFound");
            }

            else
            {
                var result = await _userService.DeleteAppUser(Appuser);
                if (result.Succeeded)
                {
                    await _userService.DeleteHomeUser(id);
                    return RedirectToAction("ManageUsers", "HomeUser");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return RedirectToAction("ManageUsers", "HomeUser");
            }
        }

        /* -------------------------------------   User/Role Part  -----------------------------------*/
        [Authorize(Roles = "Control Users")]
        [Route("Members/User-Roles")]
        [HttpGet]
        public async Task<IActionResult> ManageUserRole(int id)
        {
            var result = await _userService.GetAppUserById(id);
            var user = await _accountService.GetUserByEmail(result.Email);
            ViewData["userId"] = user.Id;
            ViewData["homeUserId"] = id;
            if (user == null)
            {
                return View("NotFound");
            }
            else
            {
                var model = await _userService.GetRolesofUser(user);
                return View(model);
            }
        }

        [Authorize(Roles = "Control Users")]
        [Route("Members/User-Roles")]
        [HttpPost]
        public async Task<IActionResult> ManageUserRole(List<UserRolesViewModel> model, int id)
        {
            var result = await _userService.GetAppUserById(id);
            var user = await _accountService.GetUserByEmail(result.Email);
            if (user == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["EditUserRoleSuccess"] = true;
                await _userService.AddRemoveUserInRole(model, user);
                return RedirectToAction("Edit", new { id = id });
            }
        }
    }
}
