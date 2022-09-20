﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.Domain.Interfaces
{
    public interface IUserRepository
    {
        public User Get(int id);

        public IEnumerable<User> GetAll();

        public User GetForAuthenticate(string email, string password);
    }
}
