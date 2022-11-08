using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.BusinessLogic.Abstraction;
using TiketsTerminal.BusinessLogic.CustomeExceptions;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.BusinessLogic.Services
{
    public class RegistrationService : IRegistrationService
    {
        protected readonly IUserService _us;
        public RegistrationService(IUserService us)
        {
            this._us = us;
        }

        public async Task<User> RegisterNewAdminAsync(User user)
        {
            await ValidateData(user);
            user.FK_Role = Domain.Enums.Role.Admin;
            user.IsApproved = true;
            await _us.SaveAsync(user);
            return user;
        }

        public async Task<User> RegisterNewUserAsync(User user)
        {
            await ValidateData(user);
            user.FK_Role = Domain.Enums.Role.User;
            await _us.SaveAsync(user);
            return user;
        }

        public async Task<bool> ValidateData(User user)
        {
            if (user == null)
                throw new ArgumentNullException("Invalid data.");
            var _user = await _us.GetByEmailAsync(user.Email);
            if (_user != null)
                throw new NotUniqueException("Email is not unique!");

            return true;
        }
    }
}
