using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.BusinessLogic.Abstraction;
using TiketsTerminal.Domain.Models;
using TiketsTerminal.Infrastucture.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace TiketsTerminal.BusinessLogic.Services
{
    public class FilmViewingTimeService : BaseService<FilmViewingTime>, IFilmViewingTimeService
    {
        public FilmViewingTimeService(dbContext db) : base(db) { }

        public async Task<List<FilmViewingTime>> GetByFilmAsync(int FilmId)
        {
            return await _db.FilmViewingTime.Where(el => el.FK_Film == FilmId).ToListAsync();
        }

        public async Task<FilmViewingTime> GetDeepDataAsync(int FilmViewingTimeId)
        {
            var FilmViewingTime = await _db.FilmViewingTime
                .Include(el => el.TicketOrders)
                .Include(el => el.Room)
                .FirstOrDefaultAsync(el => el.ID == FilmViewingTimeId);

            return FilmViewingTime;
        }

        public async Task<List<TicketOrder>> GetTicketOrdersAsync(int FilmViewingTimeId)
        {
            var list = new List<TicketOrder>();
            var FilmViewingTime = await _db.FilmViewingTime
                .Include(el => el.TicketOrders)
                .FirstOrDefaultAsync(el => el.ID == FilmViewingTimeId);
            if (FilmViewingTime == null)
                throw new Exception("Film viewing time not found!");

            return FilmViewingTime.TicketOrders.ToList();
        }

        public override async Task<FilmViewingTime> SaveAsync(FilmViewingTime item)
        {
            if (item == null)
                throw new ArgumentNullException();

            var film = await _db.Film.FindAsync(item.FK_Film);
            if (film == null)
                throw new ArgumentNullException("Film not found!");

            var room = await _db.Room.FindAsync(item.FK_Room);
            if (room == null)
                throw new ArgumentNullException("Room not found!");

            if(item.Date < DateTime.Now)
                throw new Exception("Date must be in future!");

            await base.SaveAsync(item);
            return item;
        }
    }
}
