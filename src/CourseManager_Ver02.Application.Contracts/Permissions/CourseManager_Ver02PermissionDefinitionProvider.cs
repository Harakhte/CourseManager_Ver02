using CourseManager_Ver02.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace CourseManager_Ver02.Permissions
{
    public class CourseManager_Ver02PermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(CourseManager_Ver02Permissions.GroupName);
            var teachersPermission = myGroup.AddPermission(
                CourseManager_Ver02Permissions.Teachers.Default, L("Permission:Teachers"));

            teachersPermission.AddChild(
                CourseManager_Ver02Permissions.Teachers.Create, L("Permission:Teachers.Create"));

            teachersPermission.AddChild(
                CourseManager_Ver02Permissions.Teachers.Edit, L("Permission:Teachers.Edit"));

            teachersPermission.AddChild(
                CourseManager_Ver02Permissions.Teachers.Delete, L("Permission:Teachers.Delete"));

            var studentsPermission = myGroup.AddPermission(
               CourseManager_Ver02Permissions.Students.Default, L("Permission:Students"));

            studentsPermission.AddChild(
                CourseManager_Ver02Permissions.Students.Create, L("Permission:Students.Create"));

            studentsPermission.AddChild(
                CourseManager_Ver02Permissions.Students.Edit, L("Permission:Students.Edit"));

            studentsPermission.AddChild(
                CourseManager_Ver02Permissions.Students.Delete, L("Permission:Students.Delete"));

            var coursesPermission = myGroup.AddPermission(
                CourseManager_Ver02Permissions.Courses.Default, L("Permission:Courses"));

            coursesPermission.AddChild(
                CourseManager_Ver02Permissions.Courses.Create, L("Permission:Courses.Create"));

            coursesPermission.AddChild(
                CourseManager_Ver02Permissions.Courses.Edit, L("Permission:Courses.Edit"));

            coursesPermission.AddChild(
                CourseManager_Ver02Permissions.Courses.Delete, L("Permission:Courses.Delete"));

            var classroomsPermission = myGroup.AddPermission(
               CourseManager_Ver02Permissions.Classrooms.Default, L("Permission:Classroom"));

            classroomsPermission.AddChild(
                CourseManager_Ver02Permissions.Classrooms.Create, L("Permission:Classrooms.Create"));

            classroomsPermission.AddChild(
                CourseManager_Ver02Permissions.Classrooms.Edit, L("Permission:Classrooms.Edit"));

            classroomsPermission.AddChild(
                CourseManager_Ver02Permissions.Classrooms.Delete, L("Permission:Classrooms.Delete"));
        }
    

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CourseManager_Ver02Resource>(name);
        }
    }
}
