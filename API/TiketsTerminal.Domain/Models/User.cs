using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Models.ValueModels;

namespace TiketsTerminal.Domain.Models
{
    public class User
    {
        public User() { }
        public User(RegData regData)
        {
            if (regData == null)
            {
                throw new ArgumentNullException(nameof(regData));
            }

            if (String.IsNullOrWhiteSpace(regData.Name))
                throw new ArgumentException("Name is not valid");

            ID = regData.ID;
            Email = regData.Email.Value;
            Password = regData.Password.Value;
            FK_Role = regData.Role.Value;
            Name = regData.Name;
        }

        public string Name { get; private set; }

        public int ID { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public Enums.Role FK_Role { get; private set; }

        public List<TicketOrder> TicketOrders { get; private set; }
    }
}
