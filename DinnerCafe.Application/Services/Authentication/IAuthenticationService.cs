
namespace DinnerCafe.Application.Services.Authentication;

public interface IAuthenticationService
{
  
    AuthenticationResult Login( string Email, string PassWord);
    AuthenticationResult Register(string FirstName,string Lastname, string Email,string password);
}