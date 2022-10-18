using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using CourseManager_Ver02.Permissions;

namespace CourseManager_Ver02.Students
{
    [Authorize(CourseManager_Ver02Permissions.Students.Default)]
    public class StudentAppService : CourseManager_Ver02AppService, IStudentAppService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly StudentManager _studentManager;

        public StudentAppService(
            IStudentRepository studentRepository,
            StudentManager studentManager)
        {
            _studentRepository = studentRepository;
            _studentManager = studentManager;
        }

        public async Task<StudentDto> GetAsync(Guid id)
        {
            var student = await _studentRepository.GetAsync(id);
            return ObjectMapper.Map<Student, StudentDto>(student);
        }

        public async Task<PagedResultDto<StudentDto>> GetListAsync(GetStudentListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Student.Name);
            }

            var students = await _studentRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _studentRepository.CountAsync()
                : await _studentRepository.CountAsync(
                    student => student.Name.Contains(input.Filter));

            return new PagedResultDto<StudentDto>(
                totalCount,
                ObjectMapper.Map<List<Student>, List<StudentDto>>(students)
            );
        }

        [Authorize(CourseManager_Ver02Permissions.Students.Create)]
        public async Task<StudentDto> CreateAsync(CreateStudentDto input)
        {
            var student = await _studentManager.CreateAsync(
                input.Name,
                input.BirthDate,
                input.Address,
                input.Phone,
                input.Email
            );

            await _studentRepository.InsertAsync(student);

            return ObjectMapper.Map<Student, StudentDto>(student);
        }

        [Authorize(CourseManager_Ver02Permissions.Students.Edit)]
        public async Task UpdateAsync(Guid id, UpdateStudentDto input)
        {
            var student = await _studentRepository.GetAsync(id);

            if (student.Name != input.Name)
            {
                await _studentManager.ChangeNameAsync(student, input.Name);
            }

            student.BirthDate = input.BirthDate;
            student.Address = input.Address;
            student.Phone = input.Phone;
            student.Email = input.Email;

            await _studentRepository.UpdateAsync(student);
        }

        [Authorize(CourseManager_Ver02Permissions.Students.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _studentRepository.DeleteAsync(id);
        }
    }
}
