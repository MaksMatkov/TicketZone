using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.BusinessLogic.Abstraction
{
    public interface IUserService : IBaseServise<User>
    {
        public Task<User> GetForAuthenticateAsync(string email, string password);
        public Task<User> ApproveUserAsync(int id);
    }
}
