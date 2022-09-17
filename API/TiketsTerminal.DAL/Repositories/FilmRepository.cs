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
    public class FilmRepository : IFilmRepository
    {
        DBContext db;
        public FilmRepository(DBContext _db) { this.db = _db; }
       
        public Film Get(int id)
        {
            return db.Film.Where(el => el.ID == id).FirstOrDefault();
        }

        public IEnumerable<Film> GetAll()
        {
            return db.Film;
        }

        public void Save(Film item)
        {
            try
            {
                if (item.ID > 0)
                    db.Entry(item).State = EntityState.Modified;
                else
                    db.Film.Add(item);
            }
            catch (Exception ex)
            {

            }
        }

        public void Delete(Film item)
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
