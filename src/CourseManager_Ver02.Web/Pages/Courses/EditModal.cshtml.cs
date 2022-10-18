using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourseManager_Ver02.Courses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CourseManager_Ver02.Web.Pages.Courses
{
    public class EditModalModel : CourseManager_Ver02PageModel
    {
        [BindProperty]
        public EditCourseViewModel Course { get; set; }
        public List<SelectListItem> Teachers { get; set; }

        private readonly ICourseAppService _courseAppService;
        public EditModalModel(ICourseAppService courseAppService)
        {
            _courseAppService = courseAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var courseDto = await _courseAppService.GetAsync(id);
            Course = ObjectMapper.Map<CourseDto, EditCourseViewModel>(courseDto);

            var teacherslookup = await _courseAppService.GetTeacherLookupAsync();
            Teachers = teacherslookup.Items.Select(x => new SelectListItem(x.Name, x.Id.ToString()))
                .ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _courseAppService.UpdateAsync(
                Course.Id,
                ObjectMapper.Map<EditCourseViewModel, UpdateCourseDto>(Course)
            );

            return NoContent();
        }

        public class EditCourseViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

            [Required]
            [StringLength(100)]
            public string Name { get; set; }

            public string Price { get; set; }

            public List<Guid> TeacherId { get; set; }
        }
    }
}
