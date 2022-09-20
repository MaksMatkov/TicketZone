using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.BLL.Interfaces;
using TiketsTerminal.BLL.ViewModels;
using TiketsTerminal.DAL.Infrastructure;
using TiketsTerminal.Domain.Models;
using TiketsTerminal.Domain.Models.ValueModels;

namespace TiketsTerminal.BLL.Services
{
    public class FilmService : IFilmService
    {

        public readonly UnitOfWork uow;
        public readonly AutoMapper.IMapper mapper;
        public FilmService(UnitOfWork _uow, AutoMapper.IMapper _mapper)
        {
            uow = _uow;
            mapper = _mapper;
        }

        public FilmViewModel Get(int id)
        {
            return mapper.Map<FilmViewModel>(uow.FilmRepository.Get(id));
        }

        public List<FilmViewModel> GetAll()
        {
            return mapper.Map<List<FilmViewModel>>(uow.FilmRepository.GetAll());
        }

        public void Save(FilmViewModel item)
        {
            var film = new Film(item.ID, new StringValidator(item.Name), 
                new StringValidator(item.Description), 
                new StringValidator(item.TrailerUrl), 
                new StringValidator(item.PosterUrl));

            uow.AddOrUpdate<Film>(film);
            uow.SaveChnages();
        }

        public void Delete(FilmViewModel item)
        {
            uow.FilmRepository.Save(mapper.Map<Film>(item));
            uow.SaveChnages();
        }

        public void SetViewingTime(ViewingTimeModel ViewingTimeModel)
        {
            var film = uow.FilmRepository.Get(ViewingTimeModel.FK_Film);
            if(film == null)
                throw new ArgumentException("Film is missing");
            var room = uow.RoomRepository.Get(ViewingTimeModel.FK_Room);
            if (room == null)
                throw new ArgumentException("Film is missing");

            var item = new FilmViewingTime(new DateValidator(ViewingTimeModel.Date), room, ViewingTimeModel.ID);
           
            uow.AddOrUpdate<FilmViewingTime>(item);
            uow.SaveChnages();
        }

        public void DeleteViewingTime(int id)
        {
            throw new NotImplementedException();
        }

        public void SetTicketOrder(TicketOrderViewModel TicketOrderViewModel)
        {
            var user = uow.UserRepository.Get(TicketOrderViewModel.FK_User);
            if (user == null)
                throw new ArgumentException("User is missing");
            var film = uow.FilmRepository.Get(TicketOrderViewModel.FK_Film);
            if (film == null)
                throw new ArgumentException("Film is missing");
            var viewingTime = film.FilmViewingTimes.Where(el => el.ID == TicketOrderViewModel.FK_Film_Viewing_Time).FirstOrDefault();
            if(viewingTime == null)
                throw new ArgumentException("Viewing Time is missing");
            if(viewingTime.Room == null || viewingTime.Room.ID == 0)
                throw new ArgumentException("Room is missing");


            var order = new TicketOrder(user, viewingTime, new DateValidator(TicketOrderViewModel.CreationDate), TicketOrderViewModel.ID);
            viewingTime.TicketOrders.Add(order);

            uow.SaveChnages();
        }
    }
}
