using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CourseManager_Ver02.Teachers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace CourseManager_Ver02.Web.Pages.Teachers
{
    public class CreateModalModel : CourseManager_Ver02PageModel
    {
        [BindProperty]
        public CreateTeacherViewModel Teacher { get; set; }

        private readonly ITeacherAppService _teacherAppService;

        public CreateModalModel(ITeacherAppService teacherAppService)
        {
            _teacherAppService = teacherAppService;
        }

        public void OnGet()
        {
            Teacher = new CreateTeacherViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateTeacherViewModel, CreateTeacherDto>(Teacher);
            await _teacherAppService.CreateAsync(dto);
            return NoContent();
        }

        public class CreateTeacherViewModel
        {
            [Required]
            [StringLength(100)]
            public string Name { get; set; }

            [Required]
            [DataType(DataType.Date)]
            public DateTime BirthDate { get; set; }

            public string Address { get; set; }

            public string Phone { get; set; }

            public string Email { get; set; }
        }
    }
}
