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
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(DBContext _db) : base(_db) { }

    }
}
