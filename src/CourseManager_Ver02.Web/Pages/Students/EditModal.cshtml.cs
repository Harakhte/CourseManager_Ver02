using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourseManager_Ver02.Students;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManager_Ver02.Web.Pages.Students
{
    public class EditModalModel : CourseManager_Ver02PageModel
    {
        [BindProperty]
        public EditStudentViewModel Student { get; set; }

        private readonly IStudentAppService _studentAppService;

        public EditModalModel(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var studentDto = await _studentAppService.GetAsync(id);
            Student = ObjectMapper.Map<StudentDto, EditStudentViewModel>(studentDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _studentAppService.UpdateAsync(
                Student.Id,
                ObjectMapper.Map<EditStudentViewModel, UpdateStudentDto>(Student)
            );

            return NoContent();
        }

        public class EditStudentViewModel
        {
            [HiddenInput]
            public Guid Id { get; set; }

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
