using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using CourseManager_Ver02.Permissions;
using CourseManager_Ver02.Teachers;

namespace CourseManager_Ver02.Courses
{
    [Authorize(CourseManager_Ver02Permissions.Courses.Default)]
    public class CourseAppService : CourseManager_Ver02AppService, ICourseAppService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly CourseManager _courseManager;
        private readonly ITeacherRepository _teacherRepository;

        public CourseAppService(
            ICourseRepository courseRepository,
            CourseManager courseManager,
            ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
            _courseRepository = courseRepository;
            _courseManager = courseManager;
        }


        public async Task<CourseDto> GetAsync(Guid id)
        {
            var course = await _courseRepository.GetAsync(id);
            var courseDto = ObjectMapper.Map<Course, CourseDto>(course);
            var lstteacher = await _teacherRepository.GetListAsync();

            List<string> nameTeacher = new List<string>();
            foreach (var item in course.TeacherId)
            {
                var teacherName = lstteacher.FirstOrDefault(x => x.Id == item);
                nameTeacher.Add(teacherName.Name);
            }
            courseDto.TeacherName = nameTeacher;

            return courseDto;
        }

        public async Task<PagedResultDto<CourseDto>> GetListAsync(GetCourseListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace())
            {
                input.Sorting = nameof(Course.Name);
            }

            var courses = await _courseRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var lstteacher = await _teacherRepository.GetListAsync();
            var response = ObjectMapper.Map<List<Course>, List<CourseDto>>(courses);

            foreach(var item in response)
            {
                List<string> nameTeacher = new List<string>();
                foreach (var nameId in item.TeacherId)
                {
                    var teacherName = lstteacher.FirstOrDefault(x => x.Id == nameId);
                    nameTeacher.Add(teacherName.Name);
                }
                item.TeacherName = nameTeacher;

            }

            var totalCount = input.Filter == null
                ? await _courseRepository.CountAsync()
                : await _courseRepository.CountAsync(
                    course => course.Name.Contains(input.Filter));

            return new PagedResultDto<CourseDto>(
                totalCount, response
            );
        }

        [Authorize(CourseManager_Ver02Permissions.Courses.Create)]
        public async Task<CourseDto> CreateAsync(CreateCourseDto input)
        {
            var course = await _courseManager.CreateAsync(
                input.Name,
                input.Price,
                input.TeacherId
            );

            await _courseRepository.InsertAsync(course);

            return ObjectMapper.Map<Course, CourseDto>(course);
        }

        [Authorize(CourseManager_Ver02Permissions.Courses.Edit)]
        public async Task UpdateAsync(Guid id, UpdateCourseDto input)
        {
            var course = await _courseRepository.GetAsync(id);

            if (course.Name != input.Name)
            {
                await _courseManager.ChangeNameAsync(course, input.Name);
            }

            course.Price = input.Price;
            course.TeacherId = input.TeacherId;

            await _courseRepository.UpdateAsync(course);
        }

        [Authorize(CourseManager_Ver02Permissions.Courses.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _courseRepository.DeleteAsync(id);
        }

        public async Task<ListResultDto<TeacherLookupDto>> GetTeacherLookupAsync()
        {
            var teachers = await _teacherRepository.GetListAsync();

            return new ListResultDto<TeacherLookupDto>(
                ObjectMapper.Map<List<Teacher>, List<TeacherLookupDto>>(teachers)
            );
        }
    }
}
