using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace CourseManager_Ver02.Teachers
{
    public class TeacherManager : DomainService
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherManager(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<Teacher> CreateAsync(
            [NotNull] string name,
            DateTime birthDate,
            [CanBeNull] string address = null,
            string phone = null,
            string email = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingTeacher = await _teacherRepository.FindByNameAsync(name);
            if (existingTeacher != null)
            {
                throw new TeacherAlreadyExistsException(name);
            }

            return new Teacher(
                GuidGenerator.Create(),
                name,
                birthDate,
                address,
                phone,
                email
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] Teacher teacher,
            [NotNull] string newName)
        {
            Check.NotNull(teacher, nameof(teacher));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingTeacher = await _teacherRepository.FindByNameAsync(newName);
            if (existingTeacher != null && existingTeacher.Id != teacher.Id)
            {
                throw new TeacherAlreadyExistsException(newName);
            }

            teacher.ChangeName(newName);
        }
    }
}
