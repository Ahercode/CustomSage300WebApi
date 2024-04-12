namespace CustomSage300WebApi.Dtos;

public record SageUserRequest 
    (
        string FirstName, 
        string? Surname, 
        string? OtherName, 
        string Email, 
        string? Phone, 
        string? CompanyId, 
        string? Username, 
        string? Password, 
        string? isAdmin, 
        string? Status);