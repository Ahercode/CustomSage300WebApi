namespace CustomSage300WebApi.Interfaces;

public interface IEmailService
{
    void SendEmail(string to, string subject, string body);
}