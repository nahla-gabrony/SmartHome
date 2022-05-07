using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.ViewModels.Home;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
    public class UserService : IUserService
    {
        private readonly SmartHomeContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContext;

        public UserService(SmartHomeContext context,
                           UserManager<ApplicationUser> userManager,
                           IHttpContextAccessor httpContext)
        {
            _context = context;
            _userManager = userManager;
            _httpContext = httpContext;
        }
        public string GetUserId()
        {
            return _httpContext.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
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
                    CurrentStatusDateTime = x.UserHomeLogs.Where(x => x.HomeUserId == id).OrderByDescending(x => x.Id).Select(x => x.LogDateTime).FirstOrDefault(),
                    LastEntringDateTime = x.UserHomeLogs.Where(x => x.HomeUserId == id && x.Status == true).OrderByDescending(x => x.Id).Select(x => x.LogDateTime).FirstOrDefault(),
                }).FirstOrDefaultAsync();

                HomeUsersHistory.Add(result);
            }
            return HomeUsersHistory;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAppUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<IEnumerable<HomeUser>> GetHomeUsers()
        {
            var appUsers = await _userManager.Users.ToListAsync();
            var homeUsers = await _context.HomeUsers.ToListAsync();
            homeUsers.RemoveAll(x => appUsers.Any(y => y.FirstName == x.FirstName && y.LastName == x.LastName));

            return homeUsers;
        }
    }
}
