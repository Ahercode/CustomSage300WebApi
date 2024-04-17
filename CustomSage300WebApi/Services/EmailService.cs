using CustomSage300WebApi.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace CustomSage300WebApi.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmail(string to, string subject, string body)
    {
        var from = _configuration["EmailConfiguration:From"];
        var smtpServer = _configuration["EmailConfiguration:SmtpServer"];
        var port = _configuration["EmailConfiguration:Port"];
        var smtpUsername = _configuration["EmailConfiguration:SmtpUsername"];
        var smtpPassword = _configuration["EmailConfiguration:SmtpPassword"]; 
        
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(from));
        email.To.Add(MailboxAddress.Parse(to));
        email.Subject = subject;
        email.Body = new TextPart(TextFormat.Plain) { Text = body };

        try
        {
            using var smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync(smtpServer, int.Parse(port), SecureSocketOptions.StartTls);
            await smtpClient.AuthenticateAsync(smtpUsername, smtpPassword);
            await smtpClient.SendAsync(email);
            await smtpClient.DisconnectAsync(true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
}