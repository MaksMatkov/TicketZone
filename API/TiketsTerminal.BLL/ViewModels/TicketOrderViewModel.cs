using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.BLL.ViewModels
{
    public class TicketOrderViewModel
    {
        public int ID { get; set; }
        public int FK_User { get; set; }
        public int FK_Film_Viewing_Time { get; set; }
        public int FK_Film { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
