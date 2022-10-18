using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourseManager_Ver02.Classrooms;
using CourseManager_Ver02.Courses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.ObjectMapping;

namespace CourseManager_Ver02.Web.Pages.Classrooms
{
    public class EditModalModel : CourseManager_Ver02PageModel
    {
        [BindProperty]
        public EditClassroomViewModel Classroom { get; set; }

        public List<SelectListItem> Teachers { get; set; }

        public List<SelectListItem> Students { get; set; }

        public List<SelectListItem> Courses { get; set; }

        public string coursename { get; set; }

        private readonly IClassroomAppService _classroomAppService;

        private readonly ICourseAppService _courseAppService;

        public EditModalModel(IClassroomAppService classroomAppService, ICourseAppService courseAppService)
        {
            _classroomAppService = classroomAppService;
            _courseAppService = courseAppService;
        }

        public async Task OnGetAsync(Guid id)
        {

            var classroomDto = await _classroomAppService.GetAsync(id);
            Classroom = ObjectMapper.Map<ClassroomDto, EditClassroomViewModel>(classroomDto);

            var courseid = classroomDto.CourseId;

            var teacherslookup = await _classroomAppService.GetSuitableTeacherLookupAsync(courseid);
            Teachers = teacherslookup.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();

            var courseslookup = await _classroomAppService.GetCourseLookupAsync();
            Courses = courseslookup.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();

            var courselook = await _classroomAppService.GetOneCourseNameLookupAsync(courseid);
            coursename = courselook.Name;

            var studentslookup = await _classroomAppService.GetStudentLookupAsync();
            Students = studentslookup.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _classroomAppService.UpdateAsync(
                Classroom.Id,
                ObjectMapper.Map<EditClassroomViewModel, UpdateClassroomDto>(Classroom)
            );

            return NoContent();
        }

        public class EditClassroomViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [Required]
            [StringLength(100)]
            public string Name { get; set; }

            [SelectItems(nameof(Courses))]
            [DisplayName("Course")]
            public Guid CourseId { get; set; }

            [SelectItems(nameof(Teachers))]
            [DisplayName("Teacher")]
            public List<Guid> TeacherId { get; set; }

            [SelectItems(nameof(Students))]
            [DisplayName("Student")]
            public List<Guid> StudentId { get; set; }

            public DateTime DateStart { get; set; }
            public DateTime DateEnd { get; set; }
            public List<string> SessionsEachWeek { get; set; }
            public string SessionStart { get; set; }
            public string SessionEnd { get; set; }

        }
    }
}
