using BlogWeb.Models;
using BlogWeb.Models.Authentication;

namespace BlogWeb.Services
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
