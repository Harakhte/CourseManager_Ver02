using CourseManager_Ver02.MongoDB;
using Volo.Abp.Modularity;

namespace CourseManager_Ver02
{
    [DependsOn(
        typeof(CourseManager_Ver02MongoDbTestModule)
        )]
    public class CourseManager_Ver02DomainTestModule : AbpModule
    {

    }
}