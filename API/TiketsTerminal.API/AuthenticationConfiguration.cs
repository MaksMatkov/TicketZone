using System.Text;

namespace TiketsTerminal.API
{
    public class AuthenticationConfiguration
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string Secret { get; set; }

        public int TokenLifetime { get; set; }

        public Microsoft.IdentityModel.Tokens.SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.ASCII.GetBytes(Secret));
        }
    }
}