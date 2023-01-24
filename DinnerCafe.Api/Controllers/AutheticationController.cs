using Microsoft.AspNetCore.Mvc;
using DinnerCafe.Contracts.Authentication;
using DinnerCafe.Application.Services.Authentication;
using DinnerCafe.Api.Filters;

namespace DinnerCafe.Api.Controllers;

[ApiController]
[Route("auth")]
// we can add filter in pipeline to handle error 
//[ErrorHandlingFilter]
public class AutheticationController : ControllerBase
 { private readonly IAuthenticationService _authenticationService;
    public AutheticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("Register")]
    public IActionResult Register(RegisterRequest Request)
    {
        var Response = _authenticationService.Register(Request.FirstName, Request.Lastname, Request.Email, Request.password);
        return Ok(Response);
    }

     [HttpPost("Login")]
    public IActionResult Login(LoginRequest Request)
    {
        var Response = _authenticationService.Login(Request.Email, Request.password);
        return Ok(Response);
    }
}