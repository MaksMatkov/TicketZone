using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.BusinessLogic.Abstraction;
using TiketsTerminal.BusinessLogic.CustomeExceptions;
using TiketsTerminal.Domain.Enums;
using TiketsTerminal.Domain.Models;
using TiketsTerminal.Domain.Models.NotEntity;
using TiketsTerminal.Infrastucture.Infrastructure;

namespace TiketsTerminal.BusinessLogic.Services
{
    public class TicketOrderService : BaseService<TicketOrder>, ITicketOrderService
    {
        public TicketOrderService(dbContext db) : base(db) { }

        public async Task<List<TicketOrder>> GetTicketsOrdersByUserAsync(int UserId)
        {
            var user = await _db.User
                .Include(el => el.TicketOrders)
                .FirstOrDefaultAsync(x => x.ID == UserId);

            if(user == null)
                throw new NotFoundDataException("User not found!");

            return user.TicketOrders.ToList();
        }

        public async Task<TicketOrder> SetStatusAsync(int id, Status status)
        {
            var order = await GetByKeysAsync(id);
            if(order == null)
                throw new NotFoundDataException("Order not found!");

            order.Status = status;

            await _db.SaveChangesAsync();

            return order;
        }

        public override async Task<TicketOrder> SaveAsync(TicketOrder item)
        {
            if (item == null)
                throw new ArgumentNullException("Invalid data.");

            var user = await _db.User.FindAsync(item.FK_User);
            if (user == null)
                throw new NotFoundDataException("User not found!");

            var viewingTime = await _db.FilmViewingTime
                .Include(el => el.TicketOrders)
                .Include(el => el.Room)
                .FirstOrDefaultAsync(el => el.ID == item.FK_Film_Viewing_Time);
            if (viewingTime == null)
                throw new NotFoundDataException("Film viewing time not found!");

            if(viewingTime.Room == null)
                throw new NotFoundDataException("Room not found!");

            if (viewingTime.TicketOrders.Where(el => el.Status != Status.Rejected).Count() == viewingTime.Room.SeatsCount)
                throw new NotFoundDataException("Free seats ended!");

            await base.SaveAsync(item);
            return item;
        }

        public async Task<List<TicketOrder>> GetTicketsOrdersByRoomAsync(int RoomID)
        {
            return await _db.FilmViewingTime
                .Include(el => el.TicketOrders)
                .Where(el => el.FK_Room == RoomID)
                .SelectMany(el => el.TicketOrders).ToListAsync();
        }

        public async Task<List<TicketOrder>> GetTicketsOrdersByFilmViewingTimeAsync(int FilmViewingTimeId)
        {
            return await _db.TicketOrder.Where(el => el.FK_Film_Viewing_Time == FilmViewingTimeId).ToListAsync();
        }

        public async Task<List<OrderFullInfoModel>> GetFullTicketsOrderInfoAsync()
        {
            return await _db.OrderFullInfoModel.FromSqlRaw($"EXECUTE fbd.Get_Full_Order_Model").ToListAsync();
        }
    }
}
