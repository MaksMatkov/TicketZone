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
    public class RoomService : BaseService<Room>, IRoomService
    {
        protected readonly ITicketOrderService _ticketOrderService;
        public RoomService(dbContext db, ITicketOrderService ticketOrderService) : base(db)
        {
            _ticketOrderService = ticketOrderService;
        }

        public async Task<Room> GetDeepDataAsync(params object[] keyValues)
        {
            return await _db.Room.Include(el => el.FilmViewingTimes).FirstOrDefaultAsync(el => keyValues.Contains(el.ID));
        }

        public Room GetRoomByNumber(int number)
        {
            return _db.Room.FirstOrDefault(el => el.Number == number);
        }

        public async Task<Room> GetRoomByNumberAsync(int number)
        {
            return await _db.Room.FirstOrDefaultAsync(el => el.Number == number);
        }

        public override async Task<Room> SaveAsync(Room item)
        {
            if (item == null)
                throw new NotFoundDataException("Invalid data.");

            var _oldRoom = await GetRoomByNumberAsync(item.Number);
            if (_oldRoom != null && _oldRoom.ID > 0)
                throw new NotUniqueException("Room number must be unique!");

            return await base.SaveAsync(item);
        }

        public override async Task<Room> UpdateAsync(Room item, params object[] keyValues)
        {
            if (item == null)
                throw new NotFoundDataException("Invalid data.");

            var _room = await GetDeepDataAsync(keyValues);
            if (_room == null)
                throw new NotFoundDataException("Room not found!");

            var _oldRoom = _room.Number == item.Number ? _room : await GetRoomByNumberAsync(item.Number);
            if (_oldRoom != null && _oldRoom.ID > 0 && _room.ID != _oldRoom.ID)
                throw new NotUniqueException("Room number must be unique!");

            var tikets = await _ticketOrderService.GetTicketsOrdersByRoomAsync(_room.ID);
            if(tikets.Count > 0)
            {
                var tGroups = tikets.GroupBy(el => el.FK_Film_Viewing_Time);
                if (tGroups.Where(g => g.Count() > item.SeatsCount).FirstOrDefault() != null) 
                     throw new NotAllowException("You can`t set seats count less then tickets was bought");
            }

            return await base.UpdateAsync(item, keyValues);
        }

        public override async Task<bool> Delete(int id)
        {
            var _room = await GetDeepDataAsync(id);
            if (_room == null)
                throw new NotFoundDataException("Room not found!");

            if (_room.FilmViewingTimes != null && _room.FilmViewingTimes.Count() > 0)
                throw new NotAllowException("You cannot delete a room with a scheduled session");

            return await Delete(_room);
        }
    }
}
