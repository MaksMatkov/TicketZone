using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.BLL.ViewModels;

namespace TiketsTerminal.BLL.Interfaces
{
    public interface IFilmService
    {
        public FilmViewModel Get(int id);

        public List<FilmViewModel> GetAll();

        public void Save(FilmViewModel item);

        public void Delete(FilmViewModel item);

        public void SetViewingTime(ViewingTimeModel ViewingTimeModel);

        public void DeleteViewingTime(int id);
    }
}
