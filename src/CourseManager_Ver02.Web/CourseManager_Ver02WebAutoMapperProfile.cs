using AutoMapper;
using CourseManager_Ver02.Courses;
using CourseManager_Ver02.Students;
using CourseManager_Ver02.Teachers;
using CourseManager_Ver02.Classrooms;

namespace CourseManager_Ver02.Web
{
    public class CourseManager_Ver02WebAutoMapperProfile : Profile
    {
        public CourseManager_Ver02WebAutoMapperProfile()
        {
            CreateMap<Pages.Students.CreateModalModel.CreateStudentViewModel, CreateStudentDto>();
            CreateMap<StudentDto, Pages.Students.EditModalModel.EditStudentViewModel>();
            CreateMap<Pages.Students.EditModalModel.EditStudentViewModel,UpdateStudentDto>();

            CreateMap<Pages.Teachers.CreateModalModel.CreateTeacherViewModel, CreateTeacherDto>();
            CreateMap<TeacherDto, Pages.Teachers.EditModalModel.EditTeacherViewModel>();
            CreateMap<Pages.Teachers.EditModalModel.EditTeacherViewModel, UpdateTeacherDto>();

            CreateMap<Pages.Courses.CreateModalModel.CreateCourseViewModel, CreateCourseDto>();
            CreateMap<CourseDto, Pages.Courses.EditModalModel.EditCourseViewModel>();
            CreateMap<Pages.Courses.EditModalModel.EditCourseViewModel, UpdateCourseDto>();

            CreateMap<Pages.Classrooms.CreateModalModel.CreateClassroomViewModel, CreateClassroomDto>();
            CreateMap<ClassroomDto, Pages.Classrooms.EditModalModel.EditClassroomViewModel>();
            CreateMap<Pages.Classrooms.EditModalModel.EditClassroomViewModel, UpdateClassroomDto>();
        }
    }
}
