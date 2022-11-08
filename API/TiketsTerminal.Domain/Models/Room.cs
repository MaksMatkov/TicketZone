using System;
using System.Collections.Generic;
using System.Linq;
using TiketsTerminal.Domain.Abstraction;

namespace TiketsTerminal.Domain.Models
{
    public class Room : IEntity
    {
        public int  ID { get; set; }
        public int  Number { get; set; }
        public int  SeatsCount { get; set; }
        public IEnumerable<FilmViewingTime> FilmViewingTimes { get; set; }
    }
}