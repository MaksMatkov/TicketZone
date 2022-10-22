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
            var entity = _mapper.Map<AddTicketOrderRequest, TicketOrder>(item);
            var userId = IdentityHelper.GetSub(User);
            if (userId == 0)
                throw new Exception("Not Allow!");

            entity.FK_User = userId;
            entity.Status = Domain.Enums.Status.NeedApprove;
            entity.CreationDate = DateTime.UtcNow;

            await _TicketOrderService.SaveAsync(entity);

            return _mapper.Map<TicketOrder, AddTicketOrderResponse>(entity);
        }

        
    }
}
