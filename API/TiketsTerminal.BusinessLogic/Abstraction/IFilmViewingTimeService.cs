using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.BusinessLogic.Abstraction
{
    public interface IFilmViewingTimeService : IBaseServise<FilmViewingTime>
    {
        public Task<List<FilmViewingTime>> GetByFilmAsync(int FilmId);
        public Task<FilmViewingTime> GetDeepDataAsync(params object[] keyValues);
    }
}
