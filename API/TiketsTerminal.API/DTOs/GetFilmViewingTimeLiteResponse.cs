using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiketsTerminal.API.DTOs
{
    public class GetFilmViewingTimeLiteResponse
    {
        public int id { get; set; }

        public DateTime date { get; set; }
    }
}
