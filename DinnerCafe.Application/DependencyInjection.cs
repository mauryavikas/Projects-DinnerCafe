using DinnerCafe.Application.common.Interface.Persistence;
using DinnerCafe.Application.Services.Authentication;
using Microsoft.Extensions.DependencyInjection;


namespace DinnerCafe.Application;

public static class DependencyInjection 
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IAuthenticationService, AuthenticationService>();
        
        return services;
    }
}
