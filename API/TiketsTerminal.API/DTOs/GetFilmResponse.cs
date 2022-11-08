using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiketsTerminal.API.DTOs
{
    public class GetFilmResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string trailerUrl { get; set; }
        public string posterUrl { get; set; }
        public List<GetFilmViewingTimeLiteResponse> viewingTimes { get; set; }
    }
}
