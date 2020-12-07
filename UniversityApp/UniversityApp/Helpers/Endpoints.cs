namespace UniversityApp.Helpers
{
    public class Endpoints
    {
        #region Course
        public static string GET_COURSES = "api/Courses/GetCourses/";
        public static string GET_COURSE = "api/Courses/GetCourse/";
        public static string GET_COURSE_BY_STUDENT = "api/Courses/GetCoursesByStudentId/";
        public static string GET_COURSE_BY_INSTRUCTOR = "api/Courses/GetCoursesByInstructorId/";
        public static string POST_COURSES = "api/Courses/";
        public static string PUT_COURSES = "api/Courses/";
        public static string DELETE_COURSES = "api/Courses/";
        #endregion

        #region CourseInstructor
        public static string GET_COURSE_INSTRUCTORS = "/api/CourseInstructors/";
        #endregion

        #region Department
        public static string GET_DEPARTMENTS = "api/Departments/";
        public static string POST_DEPARTMENTS = "api/Departments/";
        public static string GET_DEPARTMENT = "api/Departments/";
        public static string PUT_DEPARTMENTS = "api/Departments/";
        public static string DELETE_DEPARTMENTS = "api/Departments/";
        #endregion

        #region Student
        public static string GET_STUDENTS = "api/Students/GetStudents/";
        public static string GET_STUDENT = "api/Students/GetStudent/";
        public static string GET_STUDENT_BY_COURSE = "api/Students/GetStudentsByCourseId/";
        public static string PUT_STUDENTS = "api/Students/";
        public static string DELETE_STUDENTS = "api/Students/";
        public static string POST_STUDENTS = "api/Students/";
        #endregion

        #region Instructor
        public static string GET_INSTRUCTORS = "api/Instructors/GetInstructors/";
        public static string GET_INSTRUCTOR = "api/Instructors/GetInstructor/";
        public static string GET_INSTRUCTORS_BY_COURSEID = "api/Instructors/GetInstructorsByCourseId/";
        public static string PUT_INSTRUCTORS = "api/Instructors/";
        public static string DELETE_INSTRUCTORS = "api/Instructors/";
        public static string POST_INSTRUCTORS = "api/Instructors/";
        #endregion

        #region Enrollment
        public static string GET_ENROLLMENTS = "api/Enrollments/";
        public static string POST_ENROLLMENTS = "api/Enrollments/";
        public static string GET_ENROLLMENT = "api/Enrollments/";
        public static string PUT_ENROLLMENTS = "api/Enrollments/";
        public static string DELETE_ENROLLMENTS = "api/Enrollments/";
        #endregion

        #region OfficeAssignment
        public static string GET_OFFICEASSIGNMENTS = "api/OfficeAssignments/";
        public static string POST_OFFICEASSIGNMENTS = "api/OfficeAssignments/";
        public static string GET_OFFICEASSIGNMENT = "api/OfficeAssignments/";
        public static string PUT_OFFICEASSIGNMENTS = "api/OfficeAssignments/";
        public static string DELETE_OFFICEASSIGNMENTS = "api/OfficeAssignments/"; 
        #endregion
    }
}
