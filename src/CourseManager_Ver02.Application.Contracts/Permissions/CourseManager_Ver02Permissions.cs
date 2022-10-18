namespace CourseManager_Ver02.Permissions
{
    public static class CourseManager_Ver02Permissions
    {
        public const string GroupName = "CourseManager_Ver02";

        public static class Students
        {
            public const string Default = GroupName + ".Students";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

        public static class Teachers
        {
            public const string Default = GroupName + ".Teachers";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

        public static class Courses
        {
            public const string Default = GroupName + ".Courses";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }

        public static class Classrooms
        {
            public const string Default = GroupName + ".Classrooms";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }
}