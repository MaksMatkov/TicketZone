using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketsTerminal.BusinessLogic.Abstraction;
using TiketsTerminal.Domain.Enums;
using TiketsTerminal.Domain.Models;
using TiketsTerminal.Infrastucture.Infrastructure;

namespace TiketsTerminal.BusinessLogic.Services
{
    public class TicketOrderService : BaseService<TicketOrder>, ITicketOrderService
    {
        public TicketOrderService(dbContext db) : base(db) { }

        public async Task<List<TicketOrder>> GetUserOrdersAsync(int UserId)
        {
            var user = await _db.User
                .Include(el => el.TicketOrders)
                .FirstOrDefaultAsync(x => x.ID == UserId);

            if(user == null)
                throw new Exception("User not found!");

            return user.TicketOrders.ToList();
        }

        public async Task<TicketOrder> SetStatusAsync(int id, Status status)
        {
            var order = await GetByKeysAsync(id);
            if(order == null)
                throw new Exception("Order not found!");

            order.Status = status;
            await SaveAsync(order);
            await _db.SaveChangesAsync();

            return order;
        }

        public override async Task<TicketOrder> SaveAsync(TicketOrder item)
        {
            if (item == null)
                throw new ArgumentNullException();

            var user = await _db.User.FindAsync(item.FK_User);
            if (user == null)
                throw new Exception("User not found!");
            var viewingTime = await _db.FilmViewingTime
                .Include(el => el.TicketOrders)
                .Include(el => el.Room)
                .FirstOrDefaultAsync(el => el.ID == item.FK_Film_Viewing_Time);
            if (viewingTime == null)
                throw new Exception("Film viewing time not found!");
            if(viewingTime.TicketOrders.Count() == viewingTime.Room.SeatsCount)
                throw new Exception("Free seats ended!");

            await base.SaveAsync(item);
            return item;
        }


    }
}
