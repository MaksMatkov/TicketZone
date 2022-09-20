using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.BLL.Interfaces;
using TiketsTerminal.BLL.ViewModels;
using TiketsTerminal.DAL.Infrastructure;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.BLL.Services
{
    public class RoomService : IRoomService
    {
        public readonly UnitOfWork uow;
        public readonly AutoMapper.IMapper mapper;

        public RoomService(UnitOfWork _uow, AutoMapper.IMapper _mapper)
        {
            uow = _uow;
            mapper = _mapper;
        }

        public RoomViewModel Get(int id)
        {
            return mapper.Map<RoomViewModel>(uow.RoomRepository.Get(id));
        }

        public List<RoomViewModel> GetAll()
        {
            return mapper.Map<List<RoomViewModel>>(uow.RoomRepository.GetAll());
        }

        public void Save(RoomViewModel item)
        {

            uow.AddOrUpdate<Room>(new Room(item.ID, item.Number, item.SeatsCount));
            // uow.RoomRepository.Save(new Room(item.ID, item.Number, item.SeatsCount));
            uow.SaveChnages();
        }

        public void Delete(RoomViewModel item)
        {
            uow.RoomRepository.Save(mapper.Map<Room>(item));
            uow.SaveChnages();
        }
    }
}
