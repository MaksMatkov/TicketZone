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
        public FilmViewingTime(Film film, DateValidator date,  Room room, int id = 0)
        {
            if (film == null)
                throw new ArgumentNullException(nameof(film));
            if (date == null)
                throw new ArgumentNullException(nameof(date));
            if (room == null)
                throw new ArgumentNullException(nameof(room));

            ID = id;
            FK_Film = film.ID;
            Date = date.Value;
            FK_Room = room.ID;

            Film = film;
            Room = room;
        }

        public int ID { get; private set; }
        public int FK_Film { get; private set; }
        public DateTime Date { get; private set; }
        public int FK_Room { get; private set; }
        public Film Film { get; private set; }
        public Room Room { get; private set; }
        public List<TicketOrder> TicketOrders { get; private set; }
    }
}
