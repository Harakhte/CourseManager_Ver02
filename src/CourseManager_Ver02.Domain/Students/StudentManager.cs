using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace CourseManager_Ver02.Students
{
    public class StudentManager : DomainService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentManager(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<Student> CreateAsync(
            [NotNull] string name,
            DateTime birthDate,
            [CanBeNull] string address = null,
            string phone = null,
            string email = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingStudent = await _studentRepository.FindByNameAsync(name);
            if (existingStudent != null)
            {
                throw new StudentAlreadyExistsException(name);
            }

            return new Student(
                GuidGenerator.Create(),
                name,
                birthDate,
                address,
                phone,
                email
            );
        }

        public async Task ChangeNameAsync(
            [NotNull] Student student,
            [NotNull] string newName)
        {
            Check.NotNull(student, nameof(student));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingStudent = await _studentRepository.FindByNameAsync(newName);
            if (existingStudent != null && existingStudent.Id != student.Id)
            {
                throw new StudentAlreadyExistsException(newName);
            }

            student.ChangeName(newName);
        }
    }
}
