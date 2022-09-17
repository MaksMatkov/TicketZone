using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.BLL.ViewModels;

namespace TiketsTerminal.APP.Interfaces
{
    public interface IAuthenticationService
    {
        public UserViewModel AuthenticateUser(string email, string password);
        public string GetJWT(UserViewModel user, IOptions<AuthenticationConfiguration> options);
    }
}
