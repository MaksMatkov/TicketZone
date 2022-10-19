using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Enums;

namespace TiketsTerminal.Domain.Models
{
    public class TicketOrder
    {
        public int ID { get; private set; }
        public int FK_User { get; private set; }
        public int FK_Film_Viewing_Time { get; private set; }
        public DateTime CreationDate { get; private set; }

        public Status Status { get; private set; }
        public User User { get; set; } 
        public FilmViewingTime FilmViewingTime { get; set; }
    }
}
