using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CourseManager_Ver02.Students
{
    public interface IStudentAppService : IApplicationService
    {
        Task<StudentDto> GetAsync(Guid id);

        Task<PagedResultDto<StudentDto>> GetListAsync(GetStudentListDto input);

        Task<StudentDto> CreateAsync(CreateStudentDto input);

        Task UpdateAsync(Guid id, UpdateStudentDto input);

        Task DeleteAsync(Guid id);
    }
}
