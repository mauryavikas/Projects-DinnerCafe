namespace DinnerCafe.Contracts.Authentication;

public record AuthenticationResponse ( 
    Guid id,
    string FirstName,
    String Lastname,
    String Email,
    String Token);