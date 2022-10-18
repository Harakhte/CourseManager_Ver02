using CourseManager_Ver02.MongoDB;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace CourseManager_Ver02.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(CourseManager_Ver02MongoDbModule),
        typeof(CourseManager_Ver02ApplicationContractsModule)
        )]
    public class CourseManager_Ver02DbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
