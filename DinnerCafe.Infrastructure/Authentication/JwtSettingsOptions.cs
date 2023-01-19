using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerCafe.Infrastructure.Authentication
{
    public class JwtSettingsOptions
    {
        public const string? JwtSettings = "JwtSetting";
        public string? Secret { get; init; }
        public int ExpiryMinutes { get; init; } 
        public String? Issuer { get; init; }
        public String? Audience { get; init; }
    }
}
