using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.BusinessLogic.Abstraction;
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
            ValidateData(user);
            user.FK_Role = Domain.Enums.Role.Admin;
            await _us.SaveAsync(user);
            return user;
        }

        public async Task<User> RegisterNewUserAsync(User user)
        {
            ValidateData(user);
            user.FK_Role = Domain.Enums.Role.User;
            await _us.SaveAsync(user);
            return user;
        }

        public async void ValidateData(User user)
        {
            if (user == null)
                throw new ArgumentNullException();
            var _user = await _us.GetByEmailAsync(user.Email);
            if (_user != null)
                throw new Exception("Email is not unique!");
        }
    }
}
