using SmartHome.Data.ViewModels.Home;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
     public interface IUserService
    {
        string GetUserId();
        Task<List<HomeUsersHistoryViewModel>> GetHomeUserHistory();
        Task<IEnumerable<ApplicationUser>> GetAppUsers();
        Task<IEnumerable<HomeUser>> GetHomeUsers();
    }
}
