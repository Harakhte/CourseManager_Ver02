using System.Threading.Tasks;

namespace CourseManager_Ver02.Data
{
    public interface ICourseManager_Ver02DbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
