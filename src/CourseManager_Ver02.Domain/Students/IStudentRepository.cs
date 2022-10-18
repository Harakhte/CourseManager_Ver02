using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace CourseManager_Ver02.Students
{
    public interface IStudentRepository : IRepository<Student, Guid>
    {
        Task<Student> FindByNameAsync(string name);

        Task<List<Student>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
