using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CourseManager_Ver02.Courses
{
    public class UpdateCourseDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Price { get; set; }

        public List<Guid> TeacherId { get; set; }
    }
}
