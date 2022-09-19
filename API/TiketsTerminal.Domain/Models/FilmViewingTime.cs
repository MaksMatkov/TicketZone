using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Models.ValueModels;

namespace TiketsTerminal.Domain.Models
{
    public class FilmViewingTime
    {
        public FilmViewingTime() { }
        public FilmViewingTime(DateValidator date,  Room room, int id = 0)
        {
            //if (film == null)
            //    throw new ArgumentNullException(nameof(film));
            if (date == null)
                throw new ArgumentNullException(nameof(date));
            if (room == null)
                throw new ArgumentNullException(nameof(room));

            ID = id;            
            Date = date.Value;
            FK_Room = room.ID;

            Room = room;
        }

        public int ID { get; private set; }
        public int FK_Film { get; private set; }
        public DateTime Date { get; private set; }
        public int FK_Room { get; private set; }
        public Film Film { get; private set; }
        public Room Room { get; private set; } = new Room();
        public List<TicketOrder> TicketOrders { get; private set; } = new List<TicketOrder>();
    }
}
