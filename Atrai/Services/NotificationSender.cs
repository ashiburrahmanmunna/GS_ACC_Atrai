using FirebaseAdmin.Messaging;
using System.Threading.Tasks;

namespace Atrai.Services
{
    public class NotificationSender : INotificationSender
    {
        public async Task SendNotification(string divicetoken, string messageBody, string title)
        {

            var m = new Message()
            {
                Notification = new Notification
                {
                    Title = title,
                    Body = messageBody,

                },
                Token = divicetoken
            };
            await FirebaseMessaging.DefaultInstance.SendAsync(m);
        }
    }
}
