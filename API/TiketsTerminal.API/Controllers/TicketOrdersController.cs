using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiketsTerminal.API.DTOs;
using TiketsTerminal.API.Helpers;
using TiketsTerminal.BusinessLogic.Abstraction;
using TiketsTerminal.Domain.Enums;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketOrdersController : ControllerBase
    {
        private readonly ITicketOrderService _TicketOrderService;
        private readonly AutoMapper.IMapper _mapper;

        public TicketOrdersController(ITicketOrderService ticketOrderService, IMapper mapper)
        {
            _TicketOrderService = ticketOrderService;
            _mapper = mapper;
        }


        [HttpPost]
        [Authorize]
        public async Task<AddTicketOrderResponse> Add(AddTicketOrderRequest item)
        {
            var userId = IdentityHelper.GetSub(User);
            if (userId == 0)
                throw new Exception("Not Allow!");

            var entity = _mapper.Map<AddTicketOrderRequest, TicketOrder>(item);
            entity.FK_User = userId;
            entity.Status = Domain.Enums.Status.NeedApprove;
            entity.CreationDate = DateTime.UtcNow;

            await _TicketOrderService.SaveAsync(entity);

            return _mapper.Map<TicketOrder, AddTicketOrderResponse>(entity);
        }

        [Authorize]
        [HttpGet("myOrders")]
        public async Task<List<GetTicketOrderResponse>> GetOrders()
        {
            var userId = IdentityHelper.GetSub(User);
            if (userId == 0)
                throw new Exception("Not Allow!");

            var result = await _TicketOrderService.GetUserOrdersAsync(userId);

            return _mapper.Map<List<TicketOrder>, List<GetTicketOrderResponse>>(result.ToList());

        }

        [HttpPost("{id}/reject")]
        [Authorize]
        public async Task<bool> Reject(int id)
        {
            var order = await _TicketOrderService.GetByKeysAsync(id);
            if (order == null)
                throw new Exception("Not Found!");

            order.Status = Status.NeedReject;
            await _TicketOrderService.SaveAsync(order);

            return true;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<List<GetTicketOrderResponse>> Get()
        {
           
            var result = await _TicketOrderService.GetAsync();

            return _mapper.Map<List<TicketOrder>, List<GetTicketOrderResponse>>(result.ToList());
        }

        [HttpPost("{id}/setStatus/{status}")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> SetStatus(int id, Status status)
        {
            var order = await _TicketOrderService.GetByKeysAsync(id);
            if(order == null)
                throw new Exception("Not Found!");

            order.Status = status;
            await _TicketOrderService.SaveAsync(order);

            return true;
        }

    }
}
