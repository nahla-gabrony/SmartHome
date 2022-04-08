using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SmartHome.Data.ViewModels.Account;
using SmartHome.Data.ViewModels.Email;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public AccountService(UserManager<ApplicationUser> userManager,
                             SignInManager<ApplicationUser> signInManager,
                             IWebHostEnvironment webHostEnvironment,
                             IConfiguration configuration,
                            IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
            _emailService = emailService;
        }

        public async Task<SignInResult> PasswordSignIn(SignInViewModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RemberMe, false);
        }
        public async Task<IdentityResult> CreateAppAccount(SignUpViewModel model, string folderPath)
        {
            var user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
                Email = model.Email,
            };
            await AddCoverPhoto(model, user, folderPath);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await GenerateEmailConfirmationToken(user);
            }
            return result;
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
    
        // Hellper Function
        private async Task AddCoverPhoto(SignUpViewModel model, ApplicationUser Item, string folderPath, string ExistPhoto = null)
        {
            if (model.CoverPhoto != null)
            {
                if (ExistPhoto != null)
                {
                    string FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "profile", ExistPhoto);
                    System.IO.File.Delete(FilePath);
                }
                folderPath += Guid.NewGuid().ToString() + "_" + model.CoverPhoto.FileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
                await model.CoverPhoto.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                Item.UserImageURL = "../" + folderPath;
            }
        }
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
        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
