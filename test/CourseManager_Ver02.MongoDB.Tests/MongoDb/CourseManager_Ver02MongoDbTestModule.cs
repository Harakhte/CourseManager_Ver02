using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace CourseManager_Ver02.MongoDB
{
    [DependsOn(
        typeof(CourseManager_Ver02TestBaseModule),
        typeof(CourseManager_Ver02MongoDbModule)
        )]
    public class CourseManager_Ver02MongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var stringArray = CourseManager_Ver02MongoDbFixture.ConnectionString.Split('?');
                        var connectionString = stringArray[0].EnsureEndsWith('/')  +
                                                   "Db_" +
                                               Guid.NewGuid().ToString("N") + "/?" + stringArray[1];

            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = connectionString;
            });
        }
    }
}
