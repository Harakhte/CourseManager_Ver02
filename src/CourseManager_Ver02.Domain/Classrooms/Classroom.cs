using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ClassroomManager_Ver02.Classrooms
{
    public class Classroom : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public Guid CourseId { get; set; }
        public List<Guid> TeacherId { get; set; }
        public List<Guid> StudentId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public List<string> SessionsEachWeek { get; set; }
        public string SessionStart { get; set; }
        public string SessionEnd { get; set; }


        private Classroom()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Classroom(
            Guid id,
            [NotNull] string name,
            [CanBeNull] Guid courseId,
            [CanBeNull] List<Guid> teacherId,
            [CanBeNull] List<Guid> studentId,
            [CanBeNull] DateTime dateStart,
            [CanBeNull] DateTime dateEnd,
            [CanBeNull] string sessionStart = null,
            [CanBeNull] string sessionEnd = null,
            [CanBeNull] List<string> sessionsEachWeek = null
            )
            : base(id)
        {
            SetName(name);
            CourseId = courseId;
            TeacherId = teacherId;
            StudentId = studentId;
            DateStart = dateStart;
            DateEnd = dateEnd;
            SessionStart = sessionStart;
            SessionEnd = sessionEnd;
            SessionsEachWeek = sessionsEachWeek;
        }

        internal Classroom ChangeName([NotNull] string name)
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
