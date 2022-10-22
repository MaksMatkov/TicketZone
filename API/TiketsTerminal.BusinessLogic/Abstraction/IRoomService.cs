using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.BusinessLogic.Abstraction
{
    public interface IRoomService : IBaseServise<Room>
    {
        public Task<Room> GetRoomByNumberAsync(int number);
        public Room GetRoomByNumber(int number);
    }
}
