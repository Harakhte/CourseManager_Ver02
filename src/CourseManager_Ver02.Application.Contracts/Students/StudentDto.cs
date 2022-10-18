using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CourseManager_Ver02.Students
{
    public class StudentDto : EntityDto<Guid>
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

    }
}
