using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CourseManager_Ver02.Classrooms;
using CourseManager_Ver02.Courses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.ObjectMapping;

namespace CourseManager_Ver02.Web.Pages.Classrooms
{
    public class CreateModalModel : CourseManager_Ver02PageModel
    {
        [BindProperty]
        public CreateClassroomViewModel Classroom { get; set; }

        public List<SelectListItem> Teachers { get; set; }

        public List<SelectListItem> Students { get; set; }

        public List<SelectListItem> Courses { get; set; }

        private readonly IClassroomAppService _classroomAppService;

        private readonly ICourseAppService _courseAppService;

        public CreateModalModel(IClassroomAppService classroomAppService, ICourseAppService courseAppService)
        {
            _classroomAppService = classroomAppService;
            _courseAppService = courseAppService;
        }

        public async Task OnGetAsync()
        {
            Classroom = new CreateClassroomViewModel();

            var teacherslookup = await _courseAppService.GetTeacherLookupAsync();
            Teachers = teacherslookup.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();

            var studentslookup = await _classroomAppService.GetStudentLookupAsync();
            Students = studentslookup.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();

            var courseslookup = await _classroomAppService.GetCourseLookupAsync();
            Courses = courseslookup.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateClassroomViewModel, CreateClassroomDto>(Classroom);
            await _classroomAppService.CreateAsync(dto);
            return NoContent();
        }


        public class CreateClassroomViewModel
        {
            [Required]
            [StringLength(100)]
            public string Name { get; set; }

            [SelectItems(nameof(Courses))]
            [DisplayName("Course")]
            public Guid CourseId { get; set; }

            //[SelectItems(nameof(Teachers))]
            //[DisplayName("Teacher")]
            public List<Guid> TeacherId { get; set; }
            [SelectItems(nameof(Students))]
            [DisplayName("Student")]
            public List<Guid> StudentId { get; set; }
            public DateTime DateStart { get; set; }
            public DateTime DateEnd { get; set; }
            public string SessionStart { get; set; }
            public string SessionEnd { get; set; }
            public List<string> SessionsEachWeek { get; set; }
        }
    }
}
