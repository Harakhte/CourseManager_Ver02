using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace CourseManager_Ver02.Teachers
{
    public class Teacher : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        private Teacher()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Teacher(
            Guid id,
            [NotNull] string name,
            DateTime birthDate,
            [CanBeNull] string address = null,
            [CanBeNull] string phone = null,
            [CanBeNull] string email = null
            )
            : base(id)
        {
            SetName(name);
            BirthDate = birthDate;
            Address = address;
            Phone = phone;
            Email = email;
        }

        internal Teacher ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }

        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength: 64
            );
        }
    }
}
