using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiketsTerminal.API.DTOs
{
    public class GetFilmViewingTimeResponse
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int RoomNumber { get; set; }
        public int RoomId { get; set; }
        public int OrdersCount { get; set; }
        public int SeatsCount { get; set; }
        public int FilmId { get; set; }
    }
}
