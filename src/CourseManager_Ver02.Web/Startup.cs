using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CourseManager_Ver02.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<CourseManager_Ver02WebModule>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.InitializeApplication();
        }
    }
}
