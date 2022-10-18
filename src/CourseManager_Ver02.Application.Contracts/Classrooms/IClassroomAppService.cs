using CourseManager_Ver02.Courses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CourseManager_Ver02.Classrooms
{
    public interface IClassroomAppService : IApplicationService
    {
        Task<ClassroomDto> GetAsync(Guid id);

        Task<PagedResultDto<ClassroomDto>> GetListAsync(GetClassroomListDto input);

        Task<ClassroomDto> CreateAsync(CreateClassroomDto input);

        Task UpdateAsync(Guid id, UpdateClassroomDto input);

        Task DeleteAsync(Guid id);
        Task<CourseDto> GetOneCourseNameLookupAsync(Guid id);

        Task<ListResultDto<StudentLookupDto>> GetStudentLookupAsync();

        Task<ListResultDto<CourseLookupDto>> GetCourseLookupAsync();

        Task<ListResultDto<TeacherLookupDto>> GetTeacherLookupAsync();

        Task<ListResultDto<TeacherLookupDto>> GetSuitableTeacherLookupAsync(Guid id);


    }
}
