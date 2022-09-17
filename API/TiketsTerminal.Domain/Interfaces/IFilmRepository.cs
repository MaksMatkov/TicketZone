using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.Domain.Interfaces
{
    public interface IFilmRepository
    {
        public Film Get(int id);

        public IEnumerable<Film> GetAll();

        public void Save(Film item);
    
        public void Delete(Film item);
    }
}
