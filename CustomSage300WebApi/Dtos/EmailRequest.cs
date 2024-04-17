namespace CustomSage300WebApi.Dtos;

public record EmailRequest (
    string To,
    string Subject,
    string Body
    );