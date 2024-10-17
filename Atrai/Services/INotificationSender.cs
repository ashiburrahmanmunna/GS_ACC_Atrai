using System.Threading.Tasks;

namespace Atrai.Services
{
    public interface INotificationSender
    {
        Task SendNotification(string divicetoken, string messageBody, string title);
    }
}
