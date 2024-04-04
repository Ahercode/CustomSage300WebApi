namespace CustomSage300WebApi.Dtos;

public record SageUserResponse (int? Id, string FirstName, string? Surname, string? OtherName, string Email, 
    string? Phone, string? CompanyId, string? Username, string? isAdmin, string? Status);
    