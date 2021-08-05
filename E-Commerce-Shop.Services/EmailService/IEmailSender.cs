using System.Threading.Tasks;

namespace E_Commerce_Shop.Services.EmailService
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Message message);
    }
}