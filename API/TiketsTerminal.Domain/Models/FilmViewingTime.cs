using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.Domain.Models
{
    public class FilmViewingTime
    {
        public int ID { get; set; }
        public int FK_Film { get; set; }
        public DateTime Date { get; set; }
        public int FK_Room { get; set; }
        public Film Film { get;  set; }
        public Room Room { get; set; } 
        public IEnumerable<TicketOrder> TicketOrders { get; set; } 
    }
}
