using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.ViewModels.Account;
using SmartHome.Data.ViewModels.Home;
using SmartHome.Data.ViewModels.User;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
    public class UserService : IUserService
    {
        private readonly SmartHomeContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAccountService _accountService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserService(SmartHomeContext context,
                           UserManager<ApplicationUser> userManager,
                           RoleManager<IdentityRole> roleManager,
                           IAccountService accountService,
                           IHttpContextAccessor httpContext,
                           IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _accountService = accountService;
            _httpContext = httpContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public string GetAppUserId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
   

        public async Task<SignUpViewModel> GetHomeUserById(int id)
        {
           return await GetUserById(id);
        }

        public async Task<SignUpViewModel> GetAppUserById(int id)
        {

           var user = await GetUserById(id);

            if (user != null)
            {
                var Appuser = await GetUserByEmail(user.Email);
                var userRoles = await _userManager.GetRolesAsync(Appuser);
                user.Roles = userRoles;
                return user;
            }
            return null;
        }

       
        public async Task<SignUpViewModel> GetHomeUserByEmail(string email)
        {
            var user = await _context.HomeUsers.Where(x => x.Email == email)
                                                .Select(x => new SignUpViewModel
                                                {
                                                    HomeUserId = x.Id,
                                                    FirstName = x.FirstName,
                                                    LastName = x.LastName,
                                                    Address = x.Address,
                                                    Email = x.Email,
                                                    PhoneNumber = x.PhoneNumber,
                                                    ExistPhoto = x.UserImageURL,
                                                }).FirstOrDefaultAsync();
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public async Task<ApplicationUser> GetAppUserDetails()
        {
            var userId = GetAppUserId();
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<IEnumerable<HomeUser>> GetHomeUsersList()
        {
            var appUsers = await _userManager.Users.ToListAsync();
            var homeUsers = await _context.HomeUsers.ToListAsync();
            homeUsers.RemoveAll(x => appUsers.Any(y => y.Email == x.Email));

            return homeUsers;
        }

        public async Task<IEnumerable<HomeUser>> GetAppUsersList()
        {
            var appUsers = await _userManager.Users.ToListAsync();
            var homeUsers = await _context.HomeUsers.ToListAsync();
            var currentUser = await GetAppUserDetails();

            HashSet<string> appUsersEmail = new HashSet<string>(appUsers.Select(s => s.Email));
            var results = homeUsers.Where(m => appUsersEmail.Contains(m.Email) && m.Email != currentUser.Email).ToList();

            return results;
        }

        public async Task<IdentityResult> UpdateAppUser(SignUpViewModel model, string folderPath)
        {
            var editItem = await _userManager.FindByEmailAsync(model.Email);
            editItem.FirstName = model.FirstName;
            editItem.LastName = model.LastName;
            editItem.Email = model.Email;
            editItem.PhoneNumber = model.PhoneNumber;

            await AddAppUserCoverPhoto(model, editItem, folderPath, model.ExistPhoto);

            var result = await _userManager.UpdateAsync(editItem);

            return result;
        }
        public async Task UpdateHomeUser(SignUpViewModel model, string folderPath)
        {
            var editItem =await _context.HomeUsers.FirstOrDefaultAsync(x => x.Id == model.HomeUserId);
            editItem.FirstName = model.FirstName;
            editItem.LastName = model.LastName;
            editItem.Email = model.Email;
            editItem.PhoneNumber = model.PhoneNumber;
            editItem.Address = model.Address;
            await AddHomeUserCoverPhoto(model, editItem, folderPath, model.ExistPhoto);

             _context.HomeUsers.Update(editItem);
            await _context.SaveChangesAsync();
        }
        public async Task<IdentityResult> CreateAppUser(SignUpViewModel model, string folderPath)
        {
            var user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
                Email = model.Email,
            };
            await AddAppUserCoverPhoto(model, user, folderPath);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _accountService.GenerateEmailConfirmationToken(user);
            }
            return result;
        }
        public async Task CreateHomeUser(SignUpViewModel model, string folderPath)
        {
            var user = new HomeUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
            };
            await AddHomeUserCoverPhoto(model, user, folderPath);
            await _context.HomeUsers.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task<List<HomeUsersHistoryViewModel>> GetHomeUserHistory()
        {
            var data = await _context.HomeUsers.Select(x=>x.Id).ToListAsync();
            var HomeUsersHistory = new List<HomeUsersHistoryViewModel>();
            foreach (var id in data)
            {
                var result = await _context.HomeUsers.Where(x => x.Id == id).Select(x => new HomeUsersHistoryViewModel {
                    Id = id,
                    Name = x.FirstName + " " + x.LastName,
                    UserImageURL = x.UserImageURL,
                    Status = x.UserHomeLogs.Where(x=>x.HomeUserId == id).OrderByDescending(x=>x.Id).Select(x=>x.Status).FirstOrDefault(),
                    CurrentStatusDateTime = x.UserHomeLogs.Where(x => x.HomeUserId == id).OrderByDescending(x => x.Id).Select(x => x.StatusDateTime).FirstOrDefault(),
                    LastEntringDateTime = x.UserHomeLogs.Where(x => x.HomeUserId == id && x.Status == true).OrderByDescending(x => x.Id).Select(x => x.StatusDateTime).FirstOrDefault(),
                }).FirstOrDefaultAsync();

                HomeUsersHistory.Add(result);
            }
            return HomeUsersHistory;
        }
        public async Task<IdentityResult> DeleteAppUser(ApplicationUser user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task DeleteHomeUser(int id)
        {
            var Entity = await _context.HomeUsers.FindAsync(id);
            _context.HomeUsers.Remove(Entity);
            await _context.SaveChangesAsync();
        }
        /* -------------------------------------   User/Role Part  -----------------------------------*/

        public async Task<List<UserRolesViewModel>> GetRolesofUser(ApplicationUser user)
        {
            if (user != null)
            {
                var model = new List<UserRolesViewModel>();

                foreach (var role in _roleManager.Roles.ToList())
                {
                    var userRolesViewModel = new UserRolesViewModel
                    {
                        RoleId = role.Id,
                        RoleName = role.Name
                    };

                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        userRolesViewModel.IsSelected = true;
                    }
                    else
                    {
                        userRolesViewModel.IsSelected = false;
                    }
                    model.Add(userRolesViewModel);
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public async Task AddRemoveUserInRole(List<UserRolesViewModel> model, ApplicationUser user)
        {
            for (int i = 0; i < model.Count; i++)
            {
                var role = await _roleManager.FindByIdAsync(model[i].RoleId);
                IdentityResult result = null;

                if (model[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }
            }
        }
        // Hellper Function
        private async Task AddHomeUserCoverPhoto(SignUpViewModel model, HomeUser Item, string folderPath, string ExistPhoto = null)
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
        private async Task AddAppUserCoverPhoto(SignUpViewModel model, ApplicationUser Item, string folderPath, string ExistPhoto = null)
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
        private async Task<ApplicationUser> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        private async Task<SignUpViewModel> GetUserById(int id)
        {

            var user = await _context.HomeUsers.Where(x => x.Id == id)
                                                .Select(x => new SignUpViewModel
                                                {
                                                    HomeUserId = x.Id,
                                                    FirstName = x.FirstName,
                                                    LastName = x.LastName,
                                                    Address = x.Address,
                                                    Email = x.Email,
                                                    PhoneNumber = x.PhoneNumber,
                                                    ExistPhoto = x.UserImageURL,
                                                }).FirstOrDefaultAsync();

            if (user != null)
            {
                return user;
            }
            return null;
        }
    }
}
