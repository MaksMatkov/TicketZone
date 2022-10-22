using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiketsTerminal.Domain.Models
{
    public class User
    {
        public string Name { get; set; }

        public int ID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsApproved { get; set; } = false;

        public Enums.Role FK_Role { get; set; }

        public IEnumerable<TicketOrder> TicketOrders { get; set; }
    }
}
