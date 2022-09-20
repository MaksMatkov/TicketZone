using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Interfaces;

namespace TiketsTerminal.DAL.Infrastructure
{
    public class UnitOfWork
    {

        public readonly IUserRepository UserRepository;
        public readonly IRoomRepository RoomRepository;
        public readonly IFilmRepository FilmRepository;

        public readonly DBContext db;
        public UnitOfWork(DBContext _db,
            IUserRepository _UserRepository,
            IRoomRepository _RoomRepository,
            IFilmRepository _FilmRepository
            )
        {
            UserRepository = _UserRepository;
            RoomRepository = _RoomRepository;
            FilmRepository = _FilmRepository;
            db = _db;
        }

        public void SaveChnages() => db.SaveChanges();

        public void AddOrUpdate<T>(T item) where T : class
        {
            db.Update<T>(item);
        }

        public void Delete<T>(T item) where T : class
        {
            db.Entry(item).State = EntityState.Deleted;
        }
    }
}
