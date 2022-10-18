using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using CourseManager_Ver02.Permissions;
using CourseManager_Ver02.Teachers;
using Volo.Abp.ObjectMapping;
using ClassroomManager_Ver02.Classrooms;
using CourseManager_Ver02.Courses;
using CourseManager_Ver02.Students;

namespace CourseManager_Ver02.Classrooms
{
    [Authorize(CourseManager_Ver02Permissions.Classrooms.Default)]
    public class ClassroomAppService : CourseManager_Ver02AppService, IClassroomAppService
    {
        private readonly IClassroomRepository _classroomRepository;
        private readonly ClassroomManager _classroomManager;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public ClassroomAppService(
            IClassroomRepository classroomRepository,
            ClassroomManager classroomManager,
            ITeacherRepository teacherRepository,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository)
        {
            _teacherRepository = teacherRepository;
            _classroomRepository = classroomRepository;
            _classroomManager = classroomManager;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }


        public async Task<ClassroomDto> GetAsync(Guid id)
        {
            var classroom = await _classroomRepository.GetAsync(id);
            var classroomDto = ObjectMapper.Map<Classroom, ClassroomDto>(classroom);
            var lstteacher = await _teacherRepository.GetListAsync();
            var lststudent = await _studentRepository.GetListAsync();
            var lstcourse = await _courseRepository.GetListAsync();

            List<string> nameTeacher = new List<string>();
            foreach (var item in classroom.TeacherId)
            {
                var teacherName = lstteacher.FirstOrDefault(x => x.Id == item);
                nameTeacher.Add(teacherName.Name);
            }
            classroomDto.TeacherName = nameTeacher;

            List<string> nameStudent = new List<string>();
            foreach (var item in classroom.StudentId)
            {
                var studentName = lststudent.FirstOrDefault(x => x.Id == item);
                nameStudent.Add(studentName.Name);
            }
            classroomDto.StudentName = nameStudent;

            var courseName = lstcourse.FirstOrDefault(x => x.Id == classroom.CourseId);
            classroomDto.CourseName = courseName.Name;

            return classroomDto;
        }

        public async Task<PagedResultDto<ClassroomDto>> GetListAsync(GetClassroomListDto input)
        {
            try
            {
                if (input.Sorting.IsNullOrWhiteSpace())
                {
                    input.Sorting = nameof(Classroom.Name);
                }

                var classrooms = await _classroomRepository.GetListAsync(
                    input.SkipCount,
                    input.MaxResultCount,
                    input.Sorting,
                    input.Filter
                );

                var lstteacher = await _teacherRepository.GetListAsync();
                var response = ObjectMapper.Map<List<Classroom>, List<ClassroomDto>>(classrooms);
                var lststudent = await _studentRepository.GetListAsync();
                var lstcourse = await _courseRepository.GetListAsync();

                if (response.Count > 0)
                {
                    foreach (var item in response)
                    {
                        List<string> nameTeacher = new List<string>();
                        foreach (var nameId in item.TeacherId)
                        {
                            var teacherName = lstteacher.FirstOrDefault(x => x.Id == nameId);
                            nameTeacher.Add(teacherName.Name);
                        }
                        item.TeacherName = nameTeacher;

                        List<string> nameStudent = new List<string>();
                        foreach (var nameId in item.StudentId)
                        {
                            var studentName = lststudent.FirstOrDefault(y => y.Id == nameId);
                            nameStudent.Add(studentName.Name);
                        }
                        item.StudentName = nameStudent;

                        var courseName = lstcourse.FirstOrDefault(x => x.Id == item.CourseId);
                        item.CourseName = courseName.Name;
                    }
                }
                var totalCount = input.Filter == null
                    ? await _classroomRepository.CountAsync()
                    : await _classroomRepository.CountAsync(
                        classroom => classroom.Name.Contains(input.Filter));

                return new PagedResultDto<ClassroomDto>(
                    totalCount, response
                );
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        [Authorize(CourseManager_Ver02Permissions.Classrooms.Create)]
        public async Task<ClassroomDto> CreateAsync(CreateClassroomDto input)
        {
            // Create Async có các parameter trình tự là (name, courseId, teacherId, studentId, dateStart, dateEnd, sessionStart. sesstionEnd. sessionEachWeek)
            // Thì tham số parameter tuyền vào phải đúng theo thứ tự của Create Async được khai báo trước đó
            var classroom = await _classroomManager.CreateAsync(
                input.Name,
                input.CourseId,
                input.TeacherId,
                input.StudentId,
                input.DateStart,
                input.DateEnd,
                input.SessionStart,
                input.SessionEnd,
                input.SessionsEachWeek
            );

            await _classroomRepository.InsertAsync(classroom);

            return ObjectMapper.Map<Classroom, ClassroomDto>(classroom);
        }

        [Authorize(CourseManager_Ver02Permissions.Classrooms.Edit)]
        public async Task UpdateAsync(Guid id, UpdateClassroomDto input)
        {
            var classroom = await _classroomRepository.GetAsync(id);

            if (classroom.Name != input.Name)
            {
                await _classroomManager.ChangeNameAsync(classroom, input.Name);
            }

            classroom.CourseId = input.CourseId;
            classroom.TeacherId = input.TeacherId;
            classroom.StudentId = input.StudentId;
            classroom.DateStart = input.DateStart;
            classroom.DateEnd = input.DateEnd;
            classroom.SessionStart = input.SessionStart;
            classroom.SessionEnd = input.SessionEnd;
            classroom.SessionsEachWeek = input.SessionsEachWeek;

            await _classroomRepository.UpdateAsync(classroom);
        }

        [Authorize(CourseManager_Ver02Permissions.Classrooms.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _classroomRepository.DeleteAsync(id);
        }

        public async Task<ListResultDto<TeacherLookupDto>> GetTeacherLookupAsync()
        {
            var teachers = await _teacherRepository.GetListAsync();

            return new ListResultDto<TeacherLookupDto>(
                ObjectMapper.Map<List<Teacher>, List<TeacherLookupDto>>(teachers)
            );
        }

        public async Task<ListResultDto<StudentLookupDto>> GetStudentLookupAsync()
        {
            var students = await _studentRepository.GetListAsync();

            return new ListResultDto<StudentLookupDto>(
                ObjectMapper.Map<List<Student>, List<StudentLookupDto>>(students)
            );
        }

        public async Task<ListResultDto<CourseLookupDto>> GetCourseLookupAsync()
        {
            var courses = await _courseRepository.GetListAsync();

            return new ListResultDto<CourseLookupDto>(
                ObjectMapper.Map<List<Course>, List<CourseLookupDto>>(courses)
            );
        }

        public async Task<CourseDto> GetOneCourseNameLookupAsync(Guid id)
        {
            var course = await _courseRepository.GetAsync(id);

            return ObjectMapper.Map<Course, CourseDto>(course);
        }

        public async Task<ListResultDto<TeacherLookupDto>> GetSuitableTeacherLookupAsync(Guid id)
        {
            var teachers = await _teacherRepository.GetListAsync();
            var course = await _courseRepository.GetAsync(id);

            List<Teacher> suitableteachers = new List<Teacher>();
            foreach ( var nameId in course.TeacherId)
            {
                var teacherName = teachers.FirstOrDefault(x => x.Id == nameId);
                suitableteachers.Add(teacherName);
            }

            return new ListResultDto<TeacherLookupDto>(
                ObjectMapper.Map<List<Teacher>, List<TeacherLookupDto>>(suitableteachers)
            );
        }
    }
}
