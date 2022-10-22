using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiketsTerminal.API.DTOs
{
    public class GetRoomResponse
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public int SeatsCount { get; set; }
    }
}
