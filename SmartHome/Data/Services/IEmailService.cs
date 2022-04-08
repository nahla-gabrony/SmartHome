using SmartHome.Data.ViewModels.Email;
using System.Threading.Tasks;

namespace SmartHome.Data.Services
{
    public interface IEmailService
    {
        Task SendEmailforConfirmationEmail(UserEmailOptionsViewModel model);
        Task SendEmailforForgotPassword(UserEmailOptionsViewModel model);
    }
}