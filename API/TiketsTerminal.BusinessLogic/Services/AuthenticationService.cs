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
            var user = await _us.GetForAuthenticateAsync(email, password);
            
            if (user != null)
            {
                user.LastVisited = DateTime.UtcNow;
                await _us.SaveAsync(user);
            }
                
            return user;
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
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
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
