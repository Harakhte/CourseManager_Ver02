using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CourseManager_Ver02.Data
{
    /* This is used if database provider does't define
     * ICourseManager_Ver02DbSchemaMigrator implementation.
     */
    public class NullCourseManager_Ver02DbSchemaMigrator : ICourseManager_Ver02DbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}