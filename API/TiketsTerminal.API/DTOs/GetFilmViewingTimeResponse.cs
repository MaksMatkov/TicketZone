using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiketsTerminal.API.DTOs
{
    public class GetFilmViewingTimeResponse
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public int roomNumber { get; set; }
        public int roomId { get; set; }
        public int ordersCount { get; set; }
        public int seatsCount { get; set; }
        public int filmId { get; set; }
    }
}
