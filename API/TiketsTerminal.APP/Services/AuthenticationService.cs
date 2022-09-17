using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TiketsTerminal.APP;
using TiketsTerminal.APP.Interfaces;
using TiketsTerminal.Bll.Interfaces;
using TiketsTerminal.BLL.ViewModels;

namespace ProjectBerloga.APP.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        IUserService UserService;

        public AuthenticationService(IUserService _us)
        {
            this.UserService = _us;
        }

        public UserViewModel AuthenticateUser(string email, string password)
        {
            return UserService.GetForAuthenticate(email, password);
        }

        public string GetJWT(UserViewModel user, IOptions<AuthenticationConfiguration> options)
        {
            var authParams = options.Value;

            var SecKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(SecKey, SecurityAlgorithms.HmacSha256);
            var UserRole = user.FK_Role;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.ID.ToString()),
                new Claim(ClaimTypes.Role, UserRole.ToString())
            };

            var token = new JwtSecurityToken(
                authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
