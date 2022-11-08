using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiketsTerminal.API.DTOs
{
    public class GetRoomResponse
    {
        public int id { get; set; }
        public int number { get; set; }
        public int seatsCount { get; set; }
    }
}
