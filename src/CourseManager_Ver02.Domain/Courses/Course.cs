using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace CourseManager_Ver02.Courses
{
    public class Course : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public string Price { get; set; }
        public List<Guid> TeacherId { get; set; }
        private Course()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Course(
            Guid id,
            [NotNull] string name,
            [CanBeNull] string price = null,
            [CanBeNull] List<Guid> teacherId = null
            )
            : base(id)
        {
            SetName(name);
            Price = price;
            TeacherId = teacherId;
        }

        internal Course ChangeName([NotNull] string name)
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
