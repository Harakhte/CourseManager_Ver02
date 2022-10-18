using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace CourseManager_Ver02.Courses
{
    public class CourseManager : DomainService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseManager(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Course> CreateAsync(
            [NotNull] string name,
            [CanBeNull] string price = null,
            [CanBeNull] List<Guid> teacherId = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingCourse = await _courseRepository.FindByNameAsync(name);
            if (existingCourse != null)
            {
                throw new CourseAlreadyExistsException(name);
            }

            return new Course(
                GuidGenerator.Create(),
                name,
                price,
                teacherId
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] Course course,
            [NotNull] string newName)
        {
            Check.NotNull(course, nameof(course));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingCourse = await _courseRepository.FindByNameAsync(newName);
            if (existingCourse != null && existingCourse.Id != course.Id)
            {
                throw new CourseAlreadyExistsException(newName);
            }

            course.ChangeName(newName);
        }
    }
}
