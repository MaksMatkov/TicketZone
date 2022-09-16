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
    public class UserRepository : IUserRepository
    {
        DBContext db;
        public UserRepository(DBContext _db) { this.db = _db; }

        public User Get(int id)
        {
            return db.User.FirstOrDefault(el => el.ID == id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.User;
        }

        public void Save(User item)
        {
            try
            {
                if (item.ID > 0)
                    db.Entry(item).State = EntityState.Modified;
                else
                    db.User.Add(item);

                db.SaveChanges();
            }
            catch(Exception ex)
            {

            }
        }

        public void Delete(User item)
        {
            if (item.ID > 0)
            {
                try
                {
                    db.Entry(item).State = EntityState.Deleted;
                }
                catch (Exception ex)
                {
                   
                }
            }
        }
    }
}
