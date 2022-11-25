using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.BusinessLogic.Abstraction;
using TiketsTerminal.BusinessLogic.CustomeExceptions;
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
                throw new NotFoundDataException("User not found!");

            user.IsApproved = true;

            await _db.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _db.User.FirstOrDefaultAsync(el => el.Email == email);
        }

        public async Task<User> GetForAuthenticateAsync(string email, string password)
        {
            var user = await _db.User.FirstOrDefaultAsync(el => el.Email == email); 
            if (user == null)
                throw new NotFoundDataException("Invalid user data.");
           
            if(user.Password != password)
                throw new NotAllowException("Invalid password or email.");


            return await _db.User.FirstOrDefaultAsync(el => el.Email == email && el.Password == password);
        }

        public async Task<int> GetNotApprovedUsersCountAsync()
        {
            return await _db.User.Where(el => !el.IsApproved).CountAsync();
        }

        public override async Task<User> UpdateAsync(User item, params object[] keyValues)
        {
            if(item == null)
                throw new ArgumentNullException("Invalid data.");

            var user = await GetByKeysAsync(keyValues);
            if (user == null)
                throw new NotFoundDataException("User not found!");

            if(_db.User.FirstOrDefaultAsync(el => el.Email == item.Email && !keyValues.Contains(el.ID)) != null)
                throw new NotUniqueException("Email is not unique!");

            return await base.UpdateAsync(item, item.ID);
        }
    }
}
