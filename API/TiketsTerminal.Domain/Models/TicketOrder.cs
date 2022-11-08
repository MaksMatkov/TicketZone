using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Abstraction;
using TiketsTerminal.Domain.Enums;

namespace TiketsTerminal.Domain.Models
{
    public class TicketOrder : IEntity
    {
        public int ID { get; set; }
        public int FK_User { get; set; }
        public int FK_Film_Viewing_Time { get; set; }
        public DateTime CreationDate { get; set; }
        public Status Status { get; set; } = Status.NeedApprove;

        public User User { get; set; } 
        public FilmViewingTime FilmViewingTime { get; set; }
    }
}
