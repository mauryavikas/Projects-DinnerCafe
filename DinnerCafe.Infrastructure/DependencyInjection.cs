using DinnerCafe.Application.Common.Interface.Authentication;
using DinnerCafe.Application.Common.Interface.Services;
using DinnerCafe.Application.Services.Authentication;
using DinnerCafe.Infrastructure.Authentication;
using DinnerCafe.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using DinnerCafe.Application.common.Interface.Persistence;
using DinnerCafe.Infrastructure.persistence;

namespace DinnerCafe.infrastructure;
public static class DependencyInjection 
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,
        IConfiguration configuration)
    {   services.Configure<JwtSettingsOptions>(configuration.GetSection("JwtSetting"));
        services.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator >();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IUserRepositories, UserRepositories>();
        return services;
    }
}
