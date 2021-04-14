using AuthorizationService.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationService.Provider
{
    public class JwtAuthenticationManager:IJwtAuthenticationManager
    {
        public static List<User> userList = new List<User>()
        {
            new User{MemberId=1, Email="ams@mail.com",Password="ams@cts"},
            new User{MemberId=2, Email="ajay@mail.com",Password="ajay@cts"},
        };
        private readonly string Key;
        public JwtAuthenticationManager(string Key)
        {
            this.Key = Key;
        }

        public string GenarateToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Email, email)
                }
                ),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
       
        public User Validate(User login)
        {
           var user= userList.Where(c => c.Email == login.Email && c.Password == login.Password).FirstOrDefault();
           return user;
        }

    }
}
