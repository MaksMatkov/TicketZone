using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.BusinessLogic.Interfaces
{
    public interface IAuthenticationService
    {
        public Task<User> AuthenticateUser(string email, string password);
        public string GetJWT(User user, IOptions<AuthenticationConfiguration> options);
    }
}
