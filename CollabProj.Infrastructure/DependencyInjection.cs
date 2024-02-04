using CollabProj.Application.Interfaces.Services.Email;
using CollabProj.Application.Interfaces.Repositories;
using CollabProj.Application.Interfaces.Services;
using CollabProj.Infrastructure.Services.Email;
using CollabProj.Infrastructure.Repositories;
using CollabProj.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace CollabProj.Infrastructure
{
    public class DependencyInjection
    {
        public static void DependencyInjector(IServiceCollection service)
        {
            Log.Debug("Injecting repositories...");

            service.AddScoped<IUserRepository, UserRepository>();

            Log.Debug("Repositories successfully injected");

            Log.Debug("Injecting services...");

            service.AddScoped<IUserService, UserService>();

            service.AddScoped<ICachingService, CachingService>();

            service.AddScoped<IEmailSenderService, EmailSenderService>();

            service.AddScoped<IEmailTemplateService, EmailTemplateService>();

            service.AddScoped<ICodeGenerationService, CodeGenerationService>();

            Log.Debug("Services successfully injected");

            Log.Debug("Added Dependencies for Infrastructure");
        }
    }
}
