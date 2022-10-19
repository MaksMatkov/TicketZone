using System;
using System.Collections.Generic;
using System.Linq;

namespace TiketsTerminal.Domain.Models
{
    public class Room
    {
        public int  ID { get; private set; }
        public int  Number { get; private set; }
        public int  SeatsCount { get; private set; }
        public IEnumerable<FilmViewingTime> FilmViewingTimes { get; set; }
    }
}