namespace CustomSage300WebApi.Dtos;

public record SageModuleUserRequest (int? SageModuleId, int? UserId, string? isApprover);
