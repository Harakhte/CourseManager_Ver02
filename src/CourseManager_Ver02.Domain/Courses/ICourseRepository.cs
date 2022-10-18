using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace CourseManager_Ver02.Courses
{
    public interface ICourseRepository : IRepository<Course, Guid>
    {
        Task<Course> FindByNameAsync(string name);
        Task<List<Course>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
