﻿using GM.Core.Domain;
using GM.Manager.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GM.Data.Services
{
    public class JWTService : IJwtService
    {
        private readonly IConfiguration configuration;

        public JWTService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var chave = Encoding.ASCII.GetBytes(configuration.GetSection("JWT:Secret").Value);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email)
            };
            claims.AddRange(user.Roles.Select(p => new Claim(ClaimTypes.Role, p.Description)));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Audience = configuration.GetSection("JWT:Audience").Value,
                Issuer = configuration.GetSection("JWT:Issuer").Value,
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(configuration.GetSection("JWT:ExpiraEmMinutos").Value)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chave), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
