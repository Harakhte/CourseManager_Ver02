using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CourseManager_Ver02.Courses
{
    public class CourseDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public string Price { get; set; }

        public List<Guid> TeacherId { get; set; }

        public List<string> TeacherName { get; set; }

    }
}
