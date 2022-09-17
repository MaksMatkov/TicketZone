using System;
using System.Collections.Generic;
using System.Linq;

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

        //public int GetFreeSeatsCount(int FilmViewingTimeId)
        //{
        //    var FilmViewingTime = FilmViewingTimes.Where(el => el.ID == FilmViewingTimeId).FirstOrDefault();
        //    if(FilmViewingTime == null)
        //        throw new ArgumentException("Film Viewing Time is Not Valid!");

        //    return FilmViewingTime.TicketOrders != null ? SeatsCount - FilmViewingTime.TicketOrders.Count : SeatsCount;
        //}

        public int  ID { get; private set; }
        public int  Number { get; private set; }
        public int  SeatsCount { get; private set; }
        public List<FilmViewingTime> FilmViewingTimes { get; private set; }
    }
}