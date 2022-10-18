using Volo.Abp.Modularity;

namespace CourseManager_Ver02
{
    [DependsOn(
        typeof(CourseManager_Ver02ApplicationModule),
        typeof(CourseManager_Ver02DomainTestModule)
        )]
    public class CourseManager_Ver02ApplicationTestModule : AbpModule
    {

    }
}