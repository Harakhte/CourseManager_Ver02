using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CourseManager_Ver02.Classrooms
{
    public class StudentLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
