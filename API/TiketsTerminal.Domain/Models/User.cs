using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.Domain.Models
{
    public class User
    {
        public string Name { get; private set; }

        public int ID { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public Enums.Role FK_Role { get; private set; }

        public IEnumerable<TicketOrder> TicketOrders { get; private set; }
    }
}
