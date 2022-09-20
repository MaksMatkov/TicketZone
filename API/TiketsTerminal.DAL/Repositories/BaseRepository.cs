using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.DAL.Infrastructure;

namespace TiketsTerminal.DAL.Repositories
{
    public abstract class BaseRepository<TEntity> where TEntity :  class
    {
        protected readonly DBContext db;
        public BaseRepository(DBContext _db)
        {
            db = _db;
        }
        public TEntity Get(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

    }
}
