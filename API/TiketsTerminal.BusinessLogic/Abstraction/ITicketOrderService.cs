using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Enums;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.BusinessLogic.Abstraction
{
    public interface ITicketOrderService : IBaseServise<TicketOrder>
    {
        public Task<TicketOrder> SetStatusAsync(int id, Status status);
        public Task<List<TicketOrder>> GetUserOrdersAsync(int UserId);
    }
}
