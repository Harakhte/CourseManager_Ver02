using AutoMapper;
using ClassroomManager_Ver02.Classrooms;
using CourseManager_Ver02.Classrooms;
using CourseManager_Ver02.Courses;
using CourseManager_Ver02.Students;
using CourseManager_Ver02.Teachers;

namespace CourseManager_Ver02
{
    public class CourseManager_Ver02ApplicationAutoMapperProfile : Profile
    {
        public CourseManager_Ver02ApplicationAutoMapperProfile()
        {
            CreateMap<Student, StudentDto>();
            CreateMap<Teacher, TeacherDto>();
            CreateMap<Course, CourseDto>();

            CreateMap<Teacher, TeacherLookupDto>();
            CreateMap<Student, StudentLookupDto>();
            CreateMap<Course, CourseLookupDto>();

            CreateMap<Classroom, ClassroomDto>();

        }
    }
}
