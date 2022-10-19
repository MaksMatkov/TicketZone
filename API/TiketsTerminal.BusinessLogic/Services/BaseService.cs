using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.BusinessLogic.Abstraction;
using TiketsTerminal.Infrastucture.Infrastructure;

namespace TiketsTerminal.BusinessLogic.Services
{
    public class BaseService<T> : IBaseServise<T> where T : class
    {
        protected readonly dbContext _db;
        public BaseService(dbContext db)
        {
            _db = db;
        }

        public void Delete(T item)
        {
            if (item == null)
                throw new ArgumentNullException();

            _db.Entry(item).State = EntityState.Deleted;
            _db.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetByKeysAsync(params object[] keyValues)
        {
            return await _db.Set<T>().FindAsync(keyValues);
        }

        public async Task<T> SaveAsync(T item)
        {
            if (item == null)
                throw new ArgumentNullException();

            _db.Update<T>(item);
            await _db.SaveChangesAsync();
            return item;
        }
    }
}
