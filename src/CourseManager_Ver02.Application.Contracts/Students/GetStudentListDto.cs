using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CourseManager_Ver02.Students
{
    public class GetStudentListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
