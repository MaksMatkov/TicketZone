using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.BusinessLogic.Abstraction;
using TiketsTerminal.Domain.Models;
using TiketsTerminal.Infrastucture.Infrastructure;

namespace TiketsTerminal.BusinessLogic.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(dbContext db): base(db) { }

        public async Task<User> ApproveUserAsync(int id)
        {
            var user = await GetByKeysAsync(id);
            if (user == null)
                throw new Exception("User not found!");
            user.IsApproved = true;

            await _db.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetForAuthenticateAsync(string email, string password)
        {
            return await _db.User.FirstOrDefaultAsync(el => el.Email == email && el.Password == password && el.IsApproved);
        }
    }
}
