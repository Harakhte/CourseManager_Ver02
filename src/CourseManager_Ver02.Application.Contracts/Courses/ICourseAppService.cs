using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CourseManager_Ver02.Courses
{
    public interface ICourseAppService : IApplicationService
    {
        Task<CourseDto> GetAsync(Guid id);

        Task<PagedResultDto<CourseDto>> GetListAsync(GetCourseListDto input);

        Task<CourseDto> CreateAsync(CreateCourseDto input);

        Task UpdateAsync(Guid id, UpdateCourseDto input);

        Task DeleteAsync(Guid id);
        Task<ListResultDto<TeacherLookupDto>> GetTeacherLookupAsync();
    }
}
