using CustomSage300WebApi.Interfaces;

namespace CustomSage300WebApi.Services;

public static class ServiceConfiguration
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IUploadFileService, UploadFileService>();
    }
}