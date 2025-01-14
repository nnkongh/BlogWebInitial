namespace BlogWeb.Services
{
    public interface IIdentityMessageService
    {

        Task SendAsync(IIdentityMessageService  message);
    }
}
