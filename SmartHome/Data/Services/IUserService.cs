using Microsoft.AspNetCore.Identity;
using SmartHome.Data.ViewModels.Account;
using SmartHome.Data.ViewModels.Home;
using SmartHome.Data.ViewModels.User;
using SmartHome.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
    public interface IUserService
    {
        string GetAppUserId();
        Task<SignUpViewModel> GetHomeUserById(int id);
        Task<SignUpViewModel> GetAppUserById(int id);
        Task<SignUpViewModel> GetHomeUserByEmail(string email);
        Task UpdateHomeUser(SignUpViewModel model, string folderPath);
        Task CreateHomeUser(SignUpViewModel model, string folderPath);
        Task<IdentityResult> CreateAppUser(SignUpViewModel model, string folderPath);
        Task<List<HomeUsersHistoryViewModel>> GetHomeUserHistory();
        Task<IEnumerable<HomeUser>> GetAppUsersList();
        Task<IEnumerable<HomeUser>> GetHomeUsersList();
        Task DeleteHomeUser(int id);
        Task<ApplicationUser> GetAppUserDetails();
        Task<IdentityResult> DeleteAppUser(ApplicationUser user);
        Task<List<UserRolesViewModel>> GetRolesofUser(ApplicationUser user);
        Task AddRemoveUserInRole(List<UserRolesViewModel> model, ApplicationUser user);
        Task<IdentityResult> UpdateAppUser(SignUpViewModel model, string folderPath);
    }
}
