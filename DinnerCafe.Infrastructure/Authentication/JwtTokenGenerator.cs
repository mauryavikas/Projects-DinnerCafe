using DinnerCafe.Application.Common.Interface.Authentication;
using DinnerCafe.Application.Common.Interface.Services;
using DinnerCafe.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DinnerCafe.Infrastructure.Authentication
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly JwtSettingsOptions _JwtSettingsOptions;
        private readonly IDateTimeProvider _DateTimeProvider;

        public JwtTokenGenerator(IDateTimeProvider dateTimeProvider,IOptions<JwtSettingsOptions> jwtSettingsOptions)
        {
            _DateTimeProvider = dateTimeProvider;
            _JwtSettingsOptions = jwtSettingsOptions.Value;
        }

        public string GenerateToken(User User)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JwtSettingsOptions.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Sub,User.Id.ToString()),
                 new Claim(JwtRegisteredClaimNames.GivenName,User.FirstName),
                 new Claim(JwtRegisteredClaimNames.FamilyName,User.LastName),
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = new JwtSecurityToken( issuer:_JwtSettingsOptions.Issuer,
                audience: _JwtSettingsOptions.Audience,
                claims: claims,
                expires: _DateTimeProvider.UtcNow.AddMinutes(_JwtSettingsOptions.ExpiryMinutes),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);


        }
    }

}

