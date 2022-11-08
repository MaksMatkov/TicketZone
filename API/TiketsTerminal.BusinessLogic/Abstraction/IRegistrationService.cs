using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.BusinessLogic.Abstraction
{
    public interface IRegistrationService
    {
        public Task<User> RegisterNewUserAsync(User user);
        public Task<User> RegisterNewAdminAsync(User user);
        public Task<bool> ValidateData(User user);
    }
}
