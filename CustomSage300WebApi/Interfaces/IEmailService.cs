namespace CustomSage300WebApi.Interfaces;

public interface IEmailService
{
    Task SendEmail(string to, string subject, string body);
}