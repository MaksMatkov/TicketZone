using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiketsTerminal.API.DTOs
{
    public class GetFilmLiteResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PosterUrl { get; set; }
    }
}
