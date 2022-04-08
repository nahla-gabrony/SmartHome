using Microsoft.AspNetCore.Identity;
using SmartHome.Data.ViewModels.Account;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
    public interface IAccountService
    {
        Task<SignInResult> PasswordSignIn(SignInViewModel model);
        Task<IdentityResult> CreateAppAccount(SignUpViewModel model, string folderPath);
        Task GenerateEmailConfirmationToken(ApplicationUser user);
        Task<ApplicationUser> GetUserByEmail(string email);
        Task<IdentityResult> ConfirmEmail(string uid, string token);
        Task SignOut();
    }
}
