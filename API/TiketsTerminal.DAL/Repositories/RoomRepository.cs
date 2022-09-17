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
    public class RoomRepository : IRoomRepository
    {
        DBContext db;
        public RoomRepository(DBContext _db) { this.db = _db; }
        public Room Get(int id)
        {
            return db.Room.Where(el => el.ID == id).FirstOrDefault();
        }

        public IEnumerable<Room> GetAll()
        {
            return db.Room;
        }

        public void Save(Room item)
        {
            try
            {
                if (item.ID > 0)
                    db.Entry(item).State = EntityState.Modified;
                else
                    db.Room.Add(item);
            }
            catch (Exception ex)
            {

            }
        }

        public void Delete(Room item)
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
