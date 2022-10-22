using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.BusinessLogic.Abstraction;
using TiketsTerminal.Domain.Models;
using TiketsTerminal.Infrastucture.Infrastructure;

namespace TiketsTerminal.BusinessLogic.Services
{
    public class FilmService : BaseService<Film>, IFilmService
    {
        public FilmService(dbContext db) : base(db) { }

        public async Task<Film> GetDeepByKeysAsync(int id)
        {
            return await _db.Film.Include(el => el.FilmViewingTimes).FirstOrDefaultAsync(el => el.ID == id);
        }
    }
}
