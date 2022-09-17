using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TiketsTerminal.APP;
using TiketsTerminal.APP.Interfaces;

namespace TiketsTerminal.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService AuthenticationService;
        public readonly IOptions<AuthenticationConfiguration> options;

        public AuthenticationController(IOptions<AuthenticationConfiguration> _options, IAuthenticationService _AuthenticationService)
        {
            AuthenticationService = _AuthenticationService;
            options = _options;
        }

        [Route("login")]
        [HttpGet]
        public IActionResult Login(string email, string password)
        {
            var User = AuthenticationService.AuthenticateUser(email, password);

            if (User != null)
            {
                var AcToken = AuthenticationService.GetJWT(User, options);
                return Ok(new { access_token = AcToken, Role = (int)User.FK_Role });
            }

            return Unauthorized();
        }
    }
}
