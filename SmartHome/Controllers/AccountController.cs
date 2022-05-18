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
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserService _userService;

        public AccountController(IAccountService accountService,
                                 IUserService userService)
        {
            _accountService = accountService;
            _userService = userService;
        }

        [AllowAnonymous]
        public IActionResult SignIn()
        {
            return View();
        }

        [AllowAnonymous]
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
                    return RedirectToAction("index", "Home");
                }
                if (result.IsNotAllowed)
                {
                    ModelState.AddModelError("", "Not allowed to login");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Email or Password");
                }

            }
            return View(model);
        }
        [Authorize(Roles = "Control Users")]
        [HttpGet("Members/Add-User")]
        public IActionResult SignUp()
        {
            return View();
        }
        [Authorize(Roles = "Control Users")]
        [HttpPost("Members/Add-User")]
        public async Task<IActionResult> SignUp(SignUpViewModel model)
        {
            if (ModelState.IsValid)
            {                
                await _userService.CreateHomeUser(model, "images/profile/");
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
                    ModelState.Clear();
                }
                return RedirectToAction("ConfirmEmail", new { email = model.Email });
            }
            return View();
        }
  
        [HttpGet("Members/Confirm-Email")]
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
        
        [HttpPost("Members/Confirm-Email")]
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
        [AllowAnonymous]
        [HttpGet("Forgot-Password")]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost("Forgot-Password")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _accountService.GetUserByEmail(model.Email);
                if (user != null)
                {
                    await _accountService.GenerateForgotPasswordToken(user);
                }
                ModelState.Clear();
                model.IsSend = true;
            }
            return View(model);
        }
        [AllowAnonymous]
        [HttpGet("Reset-Password")]
        public IActionResult ResetPassword(string uid, string token)
        {
            ResetPasswordViewModel model = new ResetPasswordViewModel()
            {
                Token = token,
                UserId = uid
            };
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost("Reset-Password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Token = model.Token.Replace(" ", "+");
                var result = await _accountService.ResetPassword(model);
                if (result.Succeeded)
                {
                    ModelState.Clear();
                    model.IsSuccess = true;
                    return View(model);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        [HttpGet("Members/Change-Password")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost("Members/Change-Password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountService.ChangeUserPassword(model);
                if (result.Succeeded)
                {
                    ModelState.Clear();
                    model.IsSuccess = true;
                    return View(model);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _accountService.SignOut();
            return RedirectToAction("SignIn");
        }
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
