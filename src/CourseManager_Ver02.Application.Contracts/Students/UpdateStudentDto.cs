using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseManager_Ver02.Students
{
    public class UpdateStudentDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }
    }
}
