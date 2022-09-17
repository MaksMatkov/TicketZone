using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TiketsTerminal.Bll.Interfaces;
using TiketsTerminal.BLL.ViewModels;
using TiketsTerminal.DAL.Infrastructure;
using TiketsTerminal.Domain.Interfaces;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;
        private readonly AutoMapper.IMapper mapper;

        public UserController(IUserService _UserService, AutoMapper.IMapper _mapper)
        {
            mapper = _mapper;
            UserService = _UserService;
        }

        [HttpGet]
        public ActionResult<List<UserViewModel>> Get()
        {
            var data = new List<UserViewModel>();

            try
            {
                var users = UserService.GetAll();
                if(users != null)
                {
                    data = mapper.Map<List<UserViewModel>>(users);
                }
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }

            return Ok(data);
        }

        [HttpPut]
        [Authorize]
        public ActionResult<UserViewModel> Put(UserViewModel user)
        {
            var userID = 0;
            string userIdstr = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            Int32.TryParse(userIdstr, out userID);

            if (user == null)
                return NoContent();
            if (userID == 0 || userID != user.ID)
                return Unauthorized();

            try
            {
                UserService.Save(user);
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }

            return Ok();
        }


        [HttpPost]
        [Route("RegisterNewUser")]
        public ActionResult<UserViewModel> RegisterNewUser(UserViewModel user)
        {
            try
            {
                UserService.RegisterNewUser(user);
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }

            return Ok(user);
        }

        [HttpPost]
        [Route("RegisterNewAdmin")]
        [Authorize(Roles = "Admin")]
        public ActionResult<UserViewModel> RegisterNewAdmin(UserViewModel user)
        {
            try
            {
                UserService.RegisterNewUser(user);
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }

            return Ok(user);
        }

    }
}
