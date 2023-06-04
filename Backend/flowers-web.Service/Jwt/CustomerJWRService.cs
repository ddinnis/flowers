using flowers_web.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace flowers_web.Service
{
    public class CustomerJWRService : ICustomerJWRService
    {
        private readonly JWTTokenOptions _JWTTokenOptions;
        public CustomerJWRService(IOptionsMonitor<JWTTokenOptions> jwtTokenOptions) {
            _JWTTokenOptions = jwtTokenOptions.CurrentValue;
        }
        public string GetToken(UserRes user)
        {
            var claims = new[] {
                new Claim("Id",user.Id.ToString()),
                new Claim("NickName",user.NickName),
                new Claim("UserName",user.UserName),
                new Claim("UserType",user.UserType.ToString()),
            };

            // 需要加密 加密key
            // nuget 引入 tokens
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JWTTokenOptions.SecurityKey));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // nuget 引入 Token.JWT
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _JWTTokenOptions.Issuer,
                audience: _JWTTokenOptions.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: creds
                );
            string returnToken = new JwtSecurityTokenHandler().WriteToken(token);
            return returnToken;
        }
    }
}
