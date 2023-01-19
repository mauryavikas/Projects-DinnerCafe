using DinnerCafe.Domain.Entities;

namespace DinnerCafe.Application.Common.Interface.Authentication ;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
    
}

