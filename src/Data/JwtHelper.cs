using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using web_back.Entities;

namespace web_back.Data
{
    public class JwtHelper
    {
        public static Token GenerateToken(JwtData jwtData, in User user)
        {
            var accessToken = GenerateTokenString(jwtData, user, 15);
            var refreshToken = GenerateTokenString(jwtData, user, 35);
            return new Token(accessToken, refreshToken);
        }

        public static string GenerateTokenString(JwtData jwtData, User user, in int time)
        {
            var key = Encoding.ASCII.GetBytes
                (jwtData.JwtKey);

            Console.Write(jwtData.JwtKey);

            if (key.Length < 64)
            {
                throw new ArgumentException("Key size must be at least 512 bits for HMACSHA512", nameof(key));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString())
            }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                Issuer = jwtData.Issuer,
                Audience = jwtData.Audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            var stringToken = tokenHandler.WriteToken(token);

            return stringToken;
        }
    }
}
