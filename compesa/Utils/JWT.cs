using compesa.Models;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;

namespace compesa.Utils
{
    public static class JWT
    {

        public static ClaimsIdentity GenerateClaims(UserReturn user)
        {
            string bodyString = JsonConvert.SerializeObject(user);
            var ciList = new List<Claim>
            {
                new("body", bodyString)
            };

            var ci = new ClaimsIdentity(ciList);
            return ci;
        }

        public static string CreateToken([NotNull] UserReturn user)
        {

            var handler = new JwtSecurityTokenHandler();
            
            var key = Encoding.ASCII.GetBytes(Configuration.PrivateKey);
            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature
            );

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = GenerateClaims(user),
                SigningCredentials = credentials,
                Expires = DateTime.UtcNow.AddHours(5),
                Audience = "http://localhost:5055/",
                Issuer = "http://localhost:5055/"
            };

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }
    }
}
