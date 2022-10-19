using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TiketsTerminal.BusinessLogic.Abstraction;
using TiketsTerminal.BusinessLogic.Interfaces;
using TiketsTerminal.Domain.Models;

namespace TiketsTerminal.BusinessLogic
{
    public class AuthenticationService : IAuthenticationService
    {
        IUserService _us;

        public AuthenticationService(IUserService us)
        {
            this._us = us;
        }

        public async Task<User> AuthenticateUser(string email, string password)
        {
            return await _us.GetForAuthenticate(email, password);
        }

        public string GetJWT(User user, IOptions<AuthenticationConfiguration> options)
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
