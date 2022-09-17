using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.BLL.ViewModels
{
    public class FilmViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TrailerUrl { get; set; }
        public string PosterUrl { get; set; }
    }
}
