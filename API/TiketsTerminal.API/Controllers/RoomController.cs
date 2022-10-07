using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiketsTerminal.BLL.Interfaces;
using TiketsTerminal.BLL.ViewModels;

namespace TiketsTerminal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService RoomService;
        private readonly AutoMapper.IMapper mapper;

        public RoomController(IRoomService _RoomService, AutoMapper.IMapper _mapper)
        {
            mapper = _mapper;
            RoomService = _RoomService;
        }

        [HttpGet]
        public ActionResult<List<RoomViewModel>> Get()
        {
            var data = new List<RoomViewModel>();

            try
            {
                var users = RoomService.GetAll();
                if (users != null)
                {
                    data = mapper.Map<List<RoomViewModel>>(users);
                }
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }

            return Ok(data);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<RoomViewModel> Get(int id)
        {
            try
            {
                return Ok(RoomService.Get(id));
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles ="Admin")]
        public ActionResult<RoomViewModel> Post(RoomViewModel item)
        {
            try
            {
                RoomService.Save(item);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }
        }

    }
}
