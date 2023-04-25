using WebApplication2.Models;

namespace WebApplication2.Middleware
{

    public class CustomAuthenticateLogin : IAuthenticationLogin
    {
        private readonly JkeyInternalContext _context;
        public CustomAuthenticateLogin(JkeyInternalContext context)
        {
            _context = context;
        }
        public async Task<User> AuthenticateUser(string username, string passcode)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(passcode)){
                return new User();
            }
            else
            {
                var user = _context.Users.Where(x => x.UserName == username && x.Password == passcode).FirstOrDefault();
                if (user != null)
                {
                    return user;
                }
                else
                {
                    return new User();
                }
            }
            //return username.Equals("admin") && passcode.Equals("123123");
        }

    }
}
