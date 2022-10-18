using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace CourseManager_Ver02.Classrooms
{
    public class GetClassroomListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
