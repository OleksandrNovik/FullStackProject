using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace CollabProj.Application
{
    public class DependencyInjection
    {
        public static void DependencyInjector(IServiceCollection service)
        {
            //TODO: Add Dependencies for Application
            Log.Debug("Added Dependencies for Application");
        }
    }
}
