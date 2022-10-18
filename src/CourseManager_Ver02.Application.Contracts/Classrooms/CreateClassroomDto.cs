using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CourseManager_Ver02.Classrooms
{
    public class CreateClassroomDto
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
    }
}
