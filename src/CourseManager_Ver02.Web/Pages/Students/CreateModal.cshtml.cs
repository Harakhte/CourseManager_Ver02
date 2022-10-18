using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CourseManager_Ver02.Students;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace CourseManager_Ver02.Web.Pages.Students
{
    public class CreateModalModel : CourseManager_Ver02PageModel
    {
        [BindProperty]
        public CreateStudentViewModel Student { get; set; }

        private readonly IStudentAppService _studentAppService;

        public CreateModalModel(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }

        public void OnGet()
        {
            Student = new CreateStudentViewModel();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateStudentViewModel, CreateStudentDto>(Student);
            await _studentAppService.CreateAsync(dto);
            return NoContent();
        }

        public class CreateStudentViewModel
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
