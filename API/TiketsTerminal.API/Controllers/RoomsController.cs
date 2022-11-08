using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiketsTerminal.API.DTOs;
using TiketsTerminal.BusinessLogic.Abstraction;
using TiketsTerminal.BusinessLogic.CustomeExceptions;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly AutoMapper.IMapper _mapper;

        public RoomsController(IRoomService roomService, AutoMapper.IMapper mapper)
        {
            _mapper = mapper;
            _roomService = roomService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<List<GetRoomResponse>> Get()
        {
            var rooms = await _roomService.GetAsync();

            return _mapper.Map<List<Room>, List<GetRoomResponse>>(rooms.ToList());
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<GetRoomResponse> Get(int id)
        {
            var rooms = await _roomService.GetByKeysAsync(id);

            return _mapper.Map<Room, GetRoomResponse>(rooms);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<AddRoomResponse> Add(AddRoomRequest room)
        {
            var _room = _mapper.Map<AddRoomRequest, Room>(room);

            await _roomService.SaveAsync(_room);

            return _mapper.Map<Room, AddRoomResponse>(_room);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<AddRoomResponse> Update(int id, AddRoomRequest room)
        {
            var _roomNew = _mapper.Map<AddRoomRequest, Room>(room);

            await _roomService.UpdateAsync(_roomNew, id);

            return _mapper.Map<Room, AddRoomResponse>(_roomNew);
        }


        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> Delete(int id)
        {
            await _roomService.Delete(id);
            return true;
        }
    }
}
