namespace ISMS_API.Helpers
{
    public static class Routes
    {
        public const string Add = "Add";
        public const string Edit = "Edit";
        public const string Deactivate = "Deactivate/{id}";
        public const string Activate = "Activate/{id}";
        public const string Delete = "Delete/{id}";
        public const string RemoveStudent = "RemoveStudent";
        public const string RemoveTeacherCourseSchedule = "RemoveTeacherCourseSchedule";
        public const string CourseNotInTeacherList = "CourseNotInTeacherList";
        public const string GetList = "GetList";
        public const string Get = "Get/{id}";
        public const string GetDetails = "GetDetails";
        public const string Login = "Login";
        public const string GetStudentInfo = "GetStudentInfo";
        public const string AddTeacherCourseSchedule = "AddTeacherCourseSchedule";
        public const string GetDeanByPersonId = "GetDeanByPersonId";
        public const string GetTeacherByPersonId = "GetTeacherByPersonId";

    }
}