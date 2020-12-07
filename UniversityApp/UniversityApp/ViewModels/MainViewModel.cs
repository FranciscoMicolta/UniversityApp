using System.Threading.Tasks;
using UniversityApp.Views;
using Xamarin.Forms;

namespace UniversityApp.ViewModels
{
    public class MainViewModel
    {
        public CoursesViewModel Courses { get; set; }
        public CourseInstructorsViewModel CourseInstructors { get; set; }
        public DepartmentsViewModel Departments { get; set; }
        public StudentsViewModel Students { get; set; }
        public InstructorsViewModel Instructors { get; set; }
        public EnrollmentsViewModel Enrollments { get; set; }
        public OfficeAssignmentsViewModel OfficeAssignments { get; set; }
        public CreateCourseViewModel CreateCourse { get; set; }
        public CreateStudentViewModel CreateStudent { get; set; }
        public CreateInstructorViewModel CreateInstructor { get; set; }
        public LoginViewModel Login { get; set; }
        public HomeViewModel Home { get; set; }
        public EditCourseViewModel EditCourse { get; set; }
        public EditStudentViewModel EditStudent { get; set; }
        public EditInstructorViewModel EditInstructor { get; set; }

        public MainViewModel()
        {
            instance = this;
            Courses = new CoursesViewModel();
            CourseInstructors = new CourseInstructorsViewModel();
            Departments = new DepartmentsViewModel();
            Students = new StudentsViewModel();
            Instructors = new InstructorsViewModel();
            Enrollments = new EnrollmentsViewModel();
            OfficeAssignments = new OfficeAssignmentsViewModel();
            CreateCourse = new CreateCourseViewModel();
            CreateStudent = new CreateStudentViewModel();
            CreateInstructor = new CreateInstructorViewModel();
            Login = new LoginViewModel();
            Home = new HomeViewModel();

            CreateCourseCommand = new Command(async () => await GoToCreateCourse());
            CreateInstructorCommand = new Command(async () => await GoToCreateInstructor());
            CreateStudentCommand = new Command(async () => await GoToCreateStudent());
        }

        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if (instance == null)
                return new MainViewModel();

            return instance;
        }

        public Command CreateCourseCommand { get; set; }
        public Command CreateInstructorCommand { get; set; }
        public Command CreateStudentCommand { get; set; }

        async Task GoToCreateCourse()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CreateCoursePage());
        }

        async Task GoToCreateInstructor()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CreateInstructorPage());
        }

        async Task GoToCreateStudent()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CreateStudentPage());
        }
    }
}
