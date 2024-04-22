using System.Net;
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
        
        // email.Body = new TextPart(TextFormat.Plain) { Text = body };
       
        var header = "<h2 style='color: #125B50; text-align: center;'>Engineers and Planners</h2>";
        // var footer = "<img src='' alt='Footer Image'/>";

        body = "<p>" + body.Replace(Environment.NewLine, "</p><p>") + "</p>";
        
        var builder = new BodyBuilder();
        builder.HtmlBody = $@"
        <html>
            <body style='display: flex; justify-content: center; align-items: center;'>
                <div style='background-color: #FFF7FC; border-radius: 15px; padding: 25px; width:600px; '>
                    {header}
                    {body}
                    <p style='color: #FF0000; text-align: center; font-style: italic;'>This is a system generated email. Please do not reply to this email.</p>
                    <p style='color: #4793AF; text-align: center; font-style: italic;'>Powered by <a href='https://www.linkedin.com/in/philipaherto/'>Ahercode</a></p>
                </div>
            </body>
            
        </html>";

        email.Body = builder.ToMessageBody();

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