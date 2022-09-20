using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.DAL.Infrastructure;
using TiketsTerminal.Domain.Interfaces;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DBContext _db) : base(_db) { }

        public User GetForAuthenticate(string email, string password)
        {
            return db.User.Where(el => el.Email == email && el.Password == password).FirstOrDefault();
        }
    }
}
