using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartHome.Data.Services;
using SmartHome.Data.ViewModels.Account;
using System.Dynamic;
using System.Threading.Tasks;

namespace SmartHome.Controllers
{
    [Authorize(Roles = "Control Users")]
    public class HomeUserController : Controller
    {

        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public HomeUserController(IUserService userService,
                               IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }


        [HttpGet("Members")]
        public async Task<IActionResult> Members()
        {
            ViewBag.DeleteSuccess = TempData["DeleteSuccess"];
            var data = await _userService.GetHomeUserHistory();
            return View(data);
        }

        [HttpGet("Members/Manage-Users")]
        public async Task<IActionResult> ManageUsers()
        {
            dynamic Model = new ExpandoObject();
            Model.userApp = await _userService.GetAppUsersList();
            Model.userHome = await _userService.GetHomeUsersList();
            return View(Model);
        }

    
        [HttpGet("Members/Edit-HomeUser/{id:int:min(1)}")]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _userService.GetHomeUserById(id);
            if (data == null)
            {
                return View("NotFound");
            }
            return View(data);
        }


        [HttpPost("Members/Edit-HomeUser/{id:int:min(1)}")]
        public async Task<IActionResult> Edit(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _userService.UpdateHomeUser(model, "images/profile/");
                if (model.UserType == 2)
                {
                    var result = await _userService.CreateAppUser(model, "images/profile/");

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
            return RedirectToAction("ManageUsers");
        }
        [HttpPost("Members/Delete-HomeUser")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetHomeUserById(id);
            if (user == null)
            {
                return View("NotFound");
            }
            else
            {
                TempData["DeleteSuccess"] = true;
                await _userService.DeleteHomeUser(id);
                return RedirectToAction("ManageUsers");
            }
        }

    }
}
