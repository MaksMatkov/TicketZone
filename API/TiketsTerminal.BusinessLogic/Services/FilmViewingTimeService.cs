using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.BusinessLogic.Abstraction;
using TiketsTerminal.Domain.Models;
using TiketsTerminal.Infrastucture.Infrastructure;
using Microsoft.EntityFrameworkCore;
using TiketsTerminal.BusinessLogic.CustomeExceptions;

namespace TiketsTerminal.BusinessLogic.Services
{
    public class FilmViewingTimeService : BaseService<FilmViewingTime>, IFilmViewingTimeService
    {
        public FilmViewingTimeService(dbContext db) : base(db) { }

        public async Task<List<FilmViewingTime>> GetByFilmAsync(int FilmId)
        {
            return await _db.FilmViewingTime.Where(el => el.FK_Film == FilmId).Include(el => el.TicketOrders)
                .Include(el => el.Room).ToListAsync();
        }

        public async Task<FilmViewingTime> GetDeepDataAsync(params object[] keyValues)
        {
            var FilmViewingTime = await _db.FilmViewingTime
                .Include(el => el.TicketOrders)
                .Include(el => el.Room)
                .FirstOrDefaultAsync(el => keyValues.Contains(el.ID));

            return FilmViewingTime;
        }

        public override async Task<FilmViewingTime> SaveAsync(FilmViewingTime item)
        {
            if (item == null)
                throw new NotFoundDataException("Invalid data.");

            var film = await _db.Film.Include(el => el.FilmViewingTimes).FirstOrDefaultAsync(el => el.ID == item.FK_Film);
            if (film == null)
                throw new NotFoundDataException("Film not found!");

            var room = await _db.Room.FindAsync(item.FK_Room);
            if (room == null)
                throw new NotFoundDataException("Room not found!");

            if(item.Date < DateTime.Now)
                throw new DateNotValidException("Date must be in future!");

            if (film.FilmViewingTimes != null
                && film.FilmViewingTimes
                .FirstOrDefault(el => el.Date == item.Date) != null)
                throw new NotUniqueException("Film is have session for this day");

            await base.SaveAsync(item);
            return item;
        }

        public override async Task<FilmViewingTime> UpdateAsync(FilmViewingTime item, params object[] keyValues)
        {
            if (item == null)
                throw new NotFoundDataException("Invalid data.");

            var _item = await GetDeepDataAsync(keyValues);
            if (_item == null)
                throw new Exception("Film viewing time not found!");

            var film = await _db.Film.Include(el => el.FilmViewingTimes).FirstOrDefaultAsync(el => el.ID == item.FK_Film);
            if (film == null)
                throw new NotFoundDataException("Film not found!");

            var room = await _db.Room.FindAsync(item.FK_Room);
            if (room == null)
                throw new NotFoundDataException("Room not found!");

            if (item.Date < DateTime.Now)
                throw new DateNotValidException("Date must be in future!");

            if (film.FilmViewingTimes != null
                && film.FilmViewingTimes
                .FirstOrDefault(el => el.Date == item.Date && !keyValues.Contains(el.ID)) != null)
                throw new NotUniqueException("Film is have session for this day");

            var ticketsOrdersCount = _item.TicketOrders != null ? _item.TicketOrders.Count() : 0;
            if (ticketsOrdersCount > 0)
                if (_item.Room.ID != room.ID && room.SeatsCount < ticketsOrdersCount)
                    throw new NotAllowException("Tickets orders count for this film is more than the count of seats in this room");
            
            
            await base.UpdateAsync(_item, keyValues);
            return item;
        }

        public override async Task<bool> Delete(int id)
        {
            var item = await GetDeepDataAsync(id);
            if (item == null)
                throw new NotFoundDataException("Room not found!");

            if (item.TicketOrders != null && item.TicketOrders.Count() > 0)
                throw new NotAllowException("You cannot delete a view time with orders");

            return await Delete(item);
        }
    }
}
