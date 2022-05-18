using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SmartHome.Data.ViewModels.Account;
using SmartHome.Data.ViewModels.Email;
using SmartHome.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public AccountService(UserManager<ApplicationUser> userManager,
                             SignInManager<ApplicationUser> signInManager,
                           IHttpContextAccessor httpContext,
                             IConfiguration configuration,
                            IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
           _httpContext = httpContext;
            _configuration = configuration;
            _emailService = emailService;
        }
        public string GetAppUserId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public async Task<SignInResult> PasswordSignIn(SignInViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RemberMe, false);
        }
        public async Task GenerateEmailConfirmationToken(ApplicationUser user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendConfirmationEmail(user, token);
            }
        }
        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
        public async Task<IdentityResult> ConfirmEmail(string uid, string token)
        {
            var user = await _userManager.FindByIdAsync(uid);
            return await _userManager.ConfirmEmailAsync(user, token);
        }
        public async Task<IdentityResult> ChangeUserPassword(ChangePasswordViewModel model)
        {
            var userId = GetAppUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        }
        public async Task GenerateForgotPasswordToken(ApplicationUser user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await SendForgotPassword(user, token);
            }
        }
        public async Task<IdentityResult> ResetPassword(ResetPasswordViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            return await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
        }
        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
      
        // Hellper Function
        private async Task SendConfirmationEmail(ApplicationUser user, string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationEmail = _configuration.GetSection("Application:ConfirmationEmail").Value;
            UserEmailOptionsViewModel options = new UserEmailOptionsViewModel()
            {
                ToEmails = new List<string>() { user.Email },
                Placeholders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.FirstName),
                    new KeyValuePair<string, string>("{{Link}}", string.Format(appDomain+confirmationEmail, user.Id , token))
                }
            };
            
            await _emailService.SendEmailforConfirmationEmail(options);
        }
        private async Task SendForgotPassword(ApplicationUser user, string token)
        {
            string appDomain = _configuration.GetSection("Application:AppDomain").Value;
            string confirmationEmail = _configuration.GetSection("Application:ForgotPassword").Value;
            UserEmailOptionsViewModel options = new UserEmailOptionsViewModel()
            {
                ToEmails = new List<string>() { user.Email },
                Placeholders = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("{{UserName}}", user.FirstName),
                    new KeyValuePair<string, string>("{{Link}}", string.Format(appDomain+confirmationEmail, user.Id , token))
                }
            };

            await _emailService.SendEmailforForgotPassword(options);
        }
   
    }
}
