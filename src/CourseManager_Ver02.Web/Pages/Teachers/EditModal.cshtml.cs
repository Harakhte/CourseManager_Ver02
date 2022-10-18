using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourseManager_Ver02.Teachers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseManager_Ver02.Web.Pages.Teachers
{
    public class EditModalModel : CourseManager_Ver02PageModel
    {
        [BindProperty]
        public EditTeacherViewModel Teacher { get; set; }

        private readonly ITeacherAppService _teacherAppService;

        public EditModalModel(ITeacherAppService teacherAppService)
        {
            _teacherAppService = teacherAppService;
        }

        public async Task OnGetAsync(Guid id)
        {
            var teacherDto = await _teacherAppService.GetAsync(id);
            Teacher = ObjectMapper.Map<TeacherDto, EditTeacherViewModel>(teacherDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _teacherAppService.UpdateAsync(
                Teacher.Id,
                ObjectMapper.Map<EditTeacherViewModel, UpdateTeacherDto>(Teacher)
            );

            return NoContent();
        }

        public class EditTeacherViewModel
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
