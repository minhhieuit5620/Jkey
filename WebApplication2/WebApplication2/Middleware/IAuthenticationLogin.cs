using WebApplication2.Models;

namespace WebApplication2.Middleware
{
    public interface IAuthenticationLogin
    {
        public Task<User> AuthenticateUser(string username, string passcode);
    }
}
