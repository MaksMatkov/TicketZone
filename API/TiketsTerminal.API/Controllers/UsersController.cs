using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TiketsTerminal.API.DTOs;
using TiketsTerminal.API.Helpers;
using TiketsTerminal.BusinessLogic.Abstraction;
using TiketsTerminal.BusinessLogic.CustomeExceptions;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRegistrationService _registrationService;
        private readonly AutoMapper.IMapper _mapper;

        public UsersController(IUserService userService,
            IRegistrationService registrationService,
            AutoMapper.IMapper mapper)
        {
            _mapper = mapper;
            _userService = userService;
            _registrationService = registrationService;
        }

        [HttpGet]
        public async Task<List<GetUserResponse>> Get()
        {
            var users = await _userService.GetAsync();

            return _mapper.Map<List<User>, List<GetUserResponse>>(users.ToList());
        }

        [HttpGet("getInfo")]
        [Authorize]
        public async Task<GetUserResponse> GetInfo()
        {
            var id = IdentityHelper.GetSub(User);
            if (id == 0)
                throw new Exception("Something went wrong");
            var users = await _userService.GetByKeysAsync(id);

            return _mapper.Map<User, GetUserResponse>(users);
        }

        [HttpPost("register")]
        public async Task<AddUserResponse> AddUser(AddUserRequest user)
        {
            var _user = _mapper.Map<AddUserRequest, User>(user);
            
            await _registrationService.RegisterNewUserAsync(_user);

            return _mapper.Map<User, AddUserResponse>(_user);
        }

        //[HttpPost]
        //public async Task<AddUserResponse> AddUser(AddUserRequest user)
        //{
        //    var _user = _mapper.Map<AddUserRequest, User>(user);
        //    _user.FK_Role = Domain.Enums.Role.User;

        //    await _userService.SaveAsync(_user);

        //    return _mapper.Map<User, AddUserResponse>(_user);
        //}

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            IdentityHelper.IsAllow(id, User);
            await _userService.Delete(id);
            return true;
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<AddUserResponse> Update(int id, AddUserRequest item)
        {
            IdentityHelper.IsAllow(id, User);

            var result = await _userService.UpdateAsync(_mapper.Map<AddUserRequest, User>(item), id);

            return _mapper.Map<User, AddUserResponse>(result);
        }

        [HttpPost("approve/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<bool> ApproveUser(int id)
        {
            await _userService.ApproveUserAsync(id);

            return true;
        }

        [HttpPost("addadmin")]
        [Authorize(Roles = "Admin")]
        public async Task<AddUserResponse> AddAdmin(AddUserRequest user)
        {
            var _user = _mapper.Map<AddUserRequest, User>(user);

            await _registrationService.RegisterNewAdminAsync(_user);

            return _mapper.Map<User, AddUserResponse>(_user);
        }

        [HttpGet("notApprovedCount")]
        [Authorize(Roles = "Admin")]
        public async Task<int> GetNotApprovedCount() => await _userService.GetNotApprovedUsersCountAsync();

    }
}
