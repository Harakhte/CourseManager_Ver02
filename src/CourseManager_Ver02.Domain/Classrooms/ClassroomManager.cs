using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClassroomManager_Ver02.Classrooms;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace CourseManager_Ver02.Classrooms
{
    public class ClassroomManager : DomainService
    {
        private readonly IClassroomRepository _courseRepository;

        public ClassroomManager(IClassroomRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<Classroom> CreateAsync(
            [NotNull] string name,
            [CanBeNull] Guid courseId,
            [CanBeNull] List<Guid> teacherId,
            [CanBeNull] List<Guid> studentId,
            [CanBeNull] DateTime dateStart,
            [CanBeNull] DateTime dateEnd,
            [CanBeNull] string sessionStart,
            [CanBeNull] string sessionEnd,
            [CanBeNull] List<string> sessionsEachWeek)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingClassroom = await _courseRepository.FindByNameAsync(name);
            if (existingClassroom != null)
            {
                throw new ClassroomAlreadyExistsException(name);
            }

            return new Classroom(
                GuidGenerator.Create(),
                name,
                courseId,
                teacherId,
                studentId,
                dateStart,
                dateEnd,
                sessionStart,
                sessionEnd,
                sessionsEachWeek
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] Classroom course,
            [NotNull] string newName)
        {
            Check.NotNull(course, nameof(course));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingClassroom = await _courseRepository.FindByNameAsync(newName);
            if (existingClassroom != null && existingClassroom.Id != course.Id)
            {
                throw new ClassroomAlreadyExistsException(newName);
            }

            course.ChangeName(newName);
        }
    }
}
