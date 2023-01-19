using DinnerCafe.Application.common.Interface.Persistence;
using DinnerCafe.Application.Common.Interface.Authentication;
using DinnerCafe.Application.Services.Authentication;
using DinnerCafe.Domain.Entities;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _JwtTokenGenerator;
    private readonly IUserRepositories _userRepositories;
    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepositories userRepositories)
    {
        _JwtTokenGenerator = jwtTokenGenerator;
        _userRepositories = userRepositories;
    }

    public AuthenticationResult Login(string email, string PassWord)
    {
        //1. Validate the user  exists

        var user = _userRepositories.GetUserbyEmailId(email);

        if (user is null)
        {
            throw new Exception("User With given Email does not Exists");
        }
        //2. Validate the user  password

        if (user.Password !=PassWord)
        {
            throw new Exception("User Password is invalid ");
        }

        //3. create JWT Token      
        var Token = _JwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult( user, Token);
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //1. Validate the user does not exists
        
        if( _userRepositories.GetUserbyEmailId(email) is not null)
        {
            throw new Exception("User With given Email already Exists");
        }

        //2. create user (generate unique Id) and pesist to db 
        User user = new User
        {
            FirstName = firstName,
            LastName= lastName,
            Email = email,
            Password= password,
        };
        _userRepositories.AddUser(user);    

        //3. create JWT Token      
        var Token = _JwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult( user, Token);
    }
}