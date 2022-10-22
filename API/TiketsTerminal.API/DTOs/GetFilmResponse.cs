using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiketsTerminal.API.DTOs
{
    public class GetFilmResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TrailerUrl { get; set; }
        public string PosterUrl { get; set; }
        public List<GetFilmViewingTimeLiteResponse> ViewingTimes { get; set; }
    }
}
