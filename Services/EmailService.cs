

using SendGrid.Helpers.Mail;

namespace BlogWeb.Services
{
    public class EmailService : IIdentityMessageService
    {
       

        public async Task SendAsync(IIdentityMessageService message)
        {
            await configSendGridAsync(message);
        }

        private async Task configSendGridAsync(IIdentityMessageService message)
        {
            var myMessage = new SendGridMessage();
          
        }
    }
}
