using API.OpenPDV.Models;

namespace API.OpenPDV.Interfaces
{
    public interface IAuthService
    {
        Task<User> AuthenticateUser(string username, string password);
        string GenerateJwtToken(User user);
        Task<bool> RegisterUser(string username, string password);
    }
}
