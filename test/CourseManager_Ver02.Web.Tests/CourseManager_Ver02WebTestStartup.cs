using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace CourseManager_Ver02
{
    public class CourseManager_Ver02WebTestStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<CourseManager_Ver02WebTestModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}