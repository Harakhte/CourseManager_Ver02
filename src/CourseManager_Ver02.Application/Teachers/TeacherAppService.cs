using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using CourseManager_Ver02.Permissions;



namespace CourseManager_Ver02.Teachers
{
    [Authorize(CourseManager_Ver02Permissions.Teachers.Default)]
    public class TeacherAppService : CourseManager_Ver02AppService, ITeacherAppService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly TeacherManager _teacherManager;

        public TeacherAppService(
            ITeacherRepository teacherRepository,
            TeacherManager teacherManager)
        {
            _teacherRepository = teacherRepository;
            _teacherManager = teacherManager;
        }

        public async Task<TeacherDto> GetAsync(Guid id)
        {
            var teacher = await _teacherRepository.GetAsync(id);
            return ObjectMapper.Map<Teacher, TeacherDto>(teacher);
        }

        public async Task<PagedResultDto<TeacherDto>> GetListAsync(GetTeacherListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Teacher.Name);
            }

            var teachers = await _teacherRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _teacherRepository.CountAsync()
                : await _teacherRepository.CountAsync(
                    teacher => teacher.Name.Contains(input.Filter));

            return new PagedResultDto<TeacherDto>(
                totalCount,
                ObjectMapper.Map<List<Teacher>, List<TeacherDto>>(teachers)
            );
        }

        [Authorize(CourseManager_Ver02Permissions.Teachers.Create)]
        public async Task<TeacherDto> CreateAsync(CreateTeacherDto input)
        {
            var teacher = await _teacherManager.CreateAsync(
                input.Name,
                input.BirthDate,
                input.Address,
                input.Phone,
                input.Email
            );

            await _teacherRepository.InsertAsync(teacher);

            return ObjectMapper.Map<Teacher, TeacherDto>(teacher);
        }

        [Authorize(CourseManager_Ver02Permissions.Teachers.Edit)]
        public async Task UpdateAsync(Guid id, UpdateTeacherDto input)
        {
            var teacher = await _teacherRepository.GetAsync(id);

            if (teacher.Name != input.Name)
            {
                await _teacherManager.ChangeNameAsync(teacher, input.Name);
            }

            teacher.BirthDate = input.BirthDate;
            teacher.Address = input.Address;
            teacher.Phone = input.Phone;
            teacher.Email = input.Email;

            await _teacherRepository.UpdateAsync(teacher);
        }

        [Authorize(CourseManager_Ver02Permissions.Teachers.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _teacherRepository.DeleteAsync(id);
        }
    }
}
