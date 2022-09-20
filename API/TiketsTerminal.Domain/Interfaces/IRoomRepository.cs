using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.Domain.Interfaces
{
    public interface IRoomRepository
    {
        public Room Get(int id);

        public IEnumerable<Room> GetAll();

    }
}
