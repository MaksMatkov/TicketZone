using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.BusinessLogic.Abstraction;
using TiketsTerminal.BusinessLogic.CustomeExceptions;
using TiketsTerminal.Domain.Models;
using TiketsTerminal.Infrastucture.Infrastructure;

namespace TiketsTerminal.BusinessLogic.Services
{
    public class FilmService : BaseService<Film>, IFilmService
    {
        public FilmService(dbContext db) : base(db) { }

        public async Task<Film> GetDeepByKeysAsync(params object[] keyValues)
        {
            return await _db.Film.Include(el => el.FilmViewingTimes)
                .FirstOrDefaultAsync(el => keyValues.Contains(el.ID));
        }

        public override async Task<bool> Delete(int id)
        {
            var film = await GetDeepByKeysAsync(id);
            if(film == null)
                throw new NotFoundDataException($"Film not found.");
            
            var viewingTimesIds = film.FilmViewingTimes.Select(el => el.ID);
            if(viewingTimesIds.Count() > 0 && _db.TicketOrder.Where(el => viewingTimesIds.Contains(el.FK_Film_Viewing_Time)).FirstOrDefault() != null)
                throw new NotAllowException($"You can not delete film with ordered tickets.");

            return await Delete(film);
        }

        public async Task<bool> HardDelete(int id)
        {
            var film = await GetDeepByKeysAsync(id);
            if (film == null)
                throw new NotFoundDataException($"Film not found.");

            return await Delete(film);
        }

        public async Task<IEnumerable<Film>> GetFilmsWithSearchAsync(string searchInput = "")
        {
            if (String.IsNullOrEmpty(searchInput))
                return await base.GetAsync();

            return await _db.Film.Where(el => el.Name.ToLower().Contains(searchInput.ToLower())).ToListAsync();
        }
    }
}
