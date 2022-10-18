using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CourseManager_Ver02.Courses
{
    public class GetCourseListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
