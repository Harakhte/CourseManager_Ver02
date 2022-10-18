using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace CourseManager_Ver02.Teachers
{
    public interface ITeacherRepository : IRepository<Teacher, Guid>
    {
        Task<Teacher> FindByNameAsync(string name);

        Task<List<Teacher>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
