using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.Domain.Enums;
using TiketsTerminal.Domain.Models;
using TiketsTerminal.Domain.Models.NotEntity;

namespace TiketsTerminal.BusinessLogic.Abstraction
{
    public interface ITicketOrderService : IBaseServise<TicketOrder>
    {
        public Task<TicketOrder> SetStatusAsync(int id, Status status);
        public Task<List<TicketOrder>> GetTicketsOrdersByUserAsync(int UserId);
        public Task<List<TicketOrder>> GetTicketsOrdersByRoomAsync(int RoomID);
        public Task<List<TicketOrder>> GetTicketsOrdersByFilmViewingTimeAsync(int FilmViewingTimeId);
        public Task<List<OrderFullInfoModel>> GetFullTicketsOrderInfoAsync();
    }
}
