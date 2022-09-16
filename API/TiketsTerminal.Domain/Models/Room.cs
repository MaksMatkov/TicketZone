using System.Collections.Generic;

namespace TiketsTerminal.Domain.Models
{
    public class Room
    {
        public Room() { }
        public Room(int id, int number, int seatsCount)
        {
            ID = id;
            Number = number;
            SeatsCount = seatsCount;
        }

        public int  ID { get; private set; }
        public int  Number { get; private set; }
        public int  SeatsCount { get; private set; }
        public List<FilmViewingTime> FilmViewingTimes { get; private set; }
    }
}