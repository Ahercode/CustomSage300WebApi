namespace CustomSage300WebApi.Dtos;

public record SageModuleUserRequest (int Id, int? SageModuleId, int? UserId, string? isApprover);
