using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.BusinessLogic.Abstraction
{
    public interface IFilmService : IBaseServise<Film>
    {
        public Task<Film> GetDeepByKeysAsync(params object[] keyValues);
        public Task<bool> HardDelete(int id);
    }
}
