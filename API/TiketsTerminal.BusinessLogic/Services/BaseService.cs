using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.BusinessLogic.Abstraction;
using TiketsTerminal.BusinessLogic.CustomeExceptions;
using TiketsTerminal.Domain.Abstraction;
using TiketsTerminal.Infrastucture.Infrastructure;

namespace TiketsTerminal.BusinessLogic.Services
{
    public class BaseService<T> : IBaseServise<T> where T : class, IEntity
    {
        protected readonly dbContext _db;
        public BaseService(dbContext db)
        {
            _db = db;
        }

        public virtual async Task<bool> Delete(T item)
        {
            if (item == null)
                throw new NotFoundDataException($"{typeof(T).Name} not found.");

            _db.Entry(item).State = EntityState.Deleted;
            await _db.SaveChangesAsync();

            return true;
        }

        public virtual async Task<bool> Delete(int id)
        {
            var item = await GetByKeysAsync(id);
            if (item == null)
                throw new NotFoundDataException($"{typeof(T).Name} not found.");
            await Delete(item);

            return true;
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async Task<T> GetByKeysAsync(params object[] keyValues)
        {
            return await _db.Set<T>().FindAsync(keyValues);
        }

        public virtual async Task<T> SaveAsync(T item)
        {
            if (item == null)
                throw new ArgumentNullException("Invalid data.");

            _db.Update<T>(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public virtual async Task<T> UpdateAsync(T newValue, params object[] keyValues)
        {
            if (newValue == null)
                throw new ArgumentNullException("Invalid data.");

            var oldEntity = keyValues.Length != 0 && newValue.ID == 0 
                ? await _db.Set<T>().FindAsync(keyValues) 
                : await _db.Set<T>().FindAsync(new object[] { newValue.ID });
            if(oldEntity == null)
                throw new NotFoundDataException($"{typeof(T).Name} not found.");

            newValue.ID = oldEntity.ID;
            _db.Entry(oldEntity).CurrentValues.SetValues(newValue);
            await _db.SaveChangesAsync();
            return oldEntity;
        }
    }
}
