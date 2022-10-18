using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace CourseManager_Ver02.Teachers
{
    public interface ITeacherAppService : IApplicationService
    {
        Task<TeacherDto> GetAsync(Guid id);

        Task<PagedResultDto<TeacherDto>> GetListAsync(GetTeacherListDto input);

        Task<TeacherDto> CreateAsync(CreateTeacherDto input);

        Task UpdateAsync(Guid id, UpdateTeacherDto input);

        Task DeleteAsync(Guid id);
    }
}