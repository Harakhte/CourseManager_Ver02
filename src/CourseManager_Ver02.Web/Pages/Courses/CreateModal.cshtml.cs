using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CourseManager_Ver02.Courses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace CourseManager_Ver02.Web.Pages.Courses
{
    public class CreateModalModel : CourseManager_Ver02PageModel
    {
        [BindProperty]
        public CreateCourseViewModel Course { get; set; }

        public List<SelectListItem> Teachers { get; set; }

        private readonly ICourseAppService _courseAppService;

        public CreateModalModel(ICourseAppService courseAppService)
        {
            _courseAppService = courseAppService;
        }
        public async Task OnGetAsync()
        {
            Course = new CreateCourseViewModel();
            var teacherslookup = await _courseAppService.GetTeacherLookupAsync();
            Teachers = teacherslookup.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateCourseViewModel, CreateCourseDto>(Course);
            await _courseAppService.CreateAsync(dto);
            return NoContent();
        }

        public class CreateCourseViewModel
        {
            [Required]
            [StringLength(100)]
            public string Name { get; set; }
            public string Price { get; set; }
            [SelectItems(nameof(Teachers))]
            [DisplayName("Teacher")]
            public  List<Guid> TeacherId { get; set; }
        }
    }
}
