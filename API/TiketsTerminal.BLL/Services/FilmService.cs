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

            uow.FilmRepository.Save(film);
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
            film.FilmViewingTimes.Add(item);

            uow.SaveChnages();
        }

        public void DeleteViewingTime(int id)
        {
            throw new NotImplementedException();
        }
    }
}
