using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiketsTerminal.DAL.Infrastructure;
using TiketsTerminal.Domain.Interfaces;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UnitOfWork uow;

        public UserController(UnitOfWork _uow)
        {
            uow = _uow;
        }

        [HttpGet]
        public int GetUsersCount()
        {
            var data = uow.UserRepository.GetAll();
            return data != null ? data.Count() : 0;
        }
    }
}
