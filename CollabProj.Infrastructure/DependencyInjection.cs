using CollabProj.Application.Interfaces.Repositories;
using CollabProj.Application.Interfaces.Services;
using CollabProj.Infrastructure.Repositories;
using CollabProj.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CollabProj.Infrastructure
{
    public class DependencyInjection
    {
        public static void DependencyInjector(IServiceCollection service)
        {
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IUserService, UserService>();
            Console.WriteLine("Added Dependencies for Infrastructure");
        }
    }
}
