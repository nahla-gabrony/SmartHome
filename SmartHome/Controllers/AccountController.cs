using Microsoft.AspNetCore.Mvc;
using SmartHome.Data.Services;
using SmartHome.Data.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.CreateAppAccount(model, "images/profile/");

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }
                ModelState.Clear();
                return RedirectToAction("ConfirmEmail", new { email = model.Email });
            }
            return View();
        }
        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string uid, string token, string email)
        {
            ConfirmEmailViewModel model = new ConfirmEmailViewModel
            {
                Email = email
            };
            if (!string.IsNullOrEmpty(uid) && !string.IsNullOrEmpty(token))
            {
                token = token.Replace(" ", "+");
                var result = await _accountService.ConfirmEmail(uid, token);
                if (result.Succeeded)
                {
                    model.IsVerified = true;
                }
            }
            return View(model);
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.PasswordSignIn(model);
                var user = await _accountService.GetUserByEmail(model.Email);
                if (result.Succeeded)
                {
                    ViewData["UserImage"] = user.UserImageURL;
                    return RedirectToAction("Index", "Home", new { UserImageURL = user.UserImageURL , UserName = user.FirstName +" "+ user.LastName });
                }
                if (result.IsNotAllowed)
                {
                    ViewBag.SignInSummary = "Not allowed to login";
                }
                else
                {
                    ViewBag.SignInSummary = "Invalid Email or Password";
                }

            }
            return View(model);
        }
        [HttpPost("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailViewModel model)
        {
            var user = await _accountService.GetUserByEmail(model.Email);
            if (user != null)
            {
                if (user.EmailConfirmed)
                {
                    model.IsVerified = true;
                    return View();
                }
                await _accountService.GenerateEmailConfirmationToken(user);
                ModelState.Clear();
                model.IsSend = true;
            }
            else
            {
                ModelState.AddModelError("", "There is somthing wrong");
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _accountService.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UserManager()
        {
            return View();
        }
    }
}
