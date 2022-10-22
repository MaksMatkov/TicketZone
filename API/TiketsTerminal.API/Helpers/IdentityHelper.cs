using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TiketsTerminal.API.Helpers
{
    public static class IdentityHelper
    {
        public static bool IsAllow(int OwnerId, ClaimsPrincipal User)
        {
            var userId = 0;
            string userIdStr = User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;
            Int32.TryParse(userIdStr, out userId);
            string Role = User.FindFirst(ClaimTypes.Role)?.Value;

            if (Role != TiketsTerminal.Domain.Enums.Role.Admin.ToString() && userId != OwnerId)
                throw new Exception("Not Allow!");

            return true;
        }

        public static int GetSub(ClaimsPrincipal User)
        {
            var Id = 0;
            string IdStr = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            Int32.TryParse(IdStr, out Id);

            return Id;
        }
    }
}
