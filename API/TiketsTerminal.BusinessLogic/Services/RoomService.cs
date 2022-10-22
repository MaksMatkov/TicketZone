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
    public class RoomService : BaseService<Room>, IRoomService
    {
        public RoomService(dbContext db) : base(db) { }

        public Room GetRoomByNumber(int number)
        {
            return _db.Room.FirstOrDefault(el => el.Number == number);
        }

        public async Task<Room> GetRoomByNumberAsync(int number)
        {
            return await _db.Room.FirstOrDefaultAsync(el => el.Number == number);
        }
    }
}
