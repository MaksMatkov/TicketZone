using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Models.ValueModels;

namespace TiketsTerminal.Domain.Models
{
    public class TicketOrder
    {
        public TicketOrder() { }
        public TicketOrder(User user, FilmViewingTime vt, DateValidator creationDate, int id = 0)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            if (vt == null)
                throw new ArgumentNullException(nameof(vt));


            ID = id;
            FK_User = user.ID;
            FK_Film_Viewing_Time = vt.ID;
            CreationDate = creationDate.Value;

            User = user;
            FilmViewingTime = vt;
        }

        public int ID { get; private set; }
        public int FK_User { get; private set; }
        public int FK_Film_Viewing_Time { get; private set; }
        public DateTime CreationDate { get; private set; }
        public User User { get; private set; } = new User();
        public FilmViewingTime FilmViewingTime { get; private set; } = new FilmViewingTime();
    }
}
