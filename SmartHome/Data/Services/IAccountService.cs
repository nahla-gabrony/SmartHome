using Microsoft.AspNetCore.Identity;
using SmartHome.Data.ViewModels.Account;
using SmartHome.Data.ViewModels.User;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
    public interface IAccountService
    {
        string GetAppUserId();
        Task<SignInResult> PasswordSignIn(SignInViewModel model);
        Task GenerateEmailConfirmationToken(ApplicationUser user);
        Task<ApplicationUser> GetUserByEmail(string email);
        Task<IdentityResult> ConfirmEmail(string uid, string token);
        Task<IdentityResult> ChangeUserPassword(ChangePasswordViewModel model);
        Task<IdentityResult> ResetPassword(ResetPasswordViewModel model);
        Task GenerateForgotPasswordToken(ApplicationUser user);
        Task SignOut();



    }
}
