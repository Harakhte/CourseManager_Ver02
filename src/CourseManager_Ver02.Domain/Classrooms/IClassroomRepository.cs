using ClassroomManager_Ver02.Classrooms;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace CourseManager_Ver02.Classrooms
{
    public interface IClassroomRepository : IRepository<Classroom, Guid>
    {
        Task<Classroom> FindByNameAsync(string name);
        Task<List<Classroom>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
