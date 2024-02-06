using Serilog;

namespace CollabProj.Server
{
    public class DependencyInjection
    {
        public static void DependencyInjector(IServiceCollection service)
        {
            //TODO: Add Dependencies for Presentation
            Log.Debug("Added Dependencies for Presentation");
        }
    }
}
