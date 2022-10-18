using Volo.Abp.Application.Dtos;

namespace CourseManager_Ver02.Teachers
{
    public class GetTeacherListDto : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}

