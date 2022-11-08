using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Abstraction;

namespace TiketsTerminal.Domain.Models
{
    public class User : IEntity
    {
        public string Name { get; set; }

        public int ID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsApproved { get; set; } = false;

        public DateTime LastVisited { get; set; }

        public Enums.Role FK_Role { get; set; }

        public IEnumerable<TicketOrder> TicketOrders { get; set; }
    }
}
