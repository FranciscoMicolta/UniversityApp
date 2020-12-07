using System.Threading.Tasks;
using UniversityApp.Views;
using Xamarin.Forms;

namespace UniversityApp.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
            GoToCoursesCommand = new Command(async () => await GoToCourses());
            GoToInstructorsCommand = new Command(async () => await GoToInstructors());
            GoToStudentsCommand = new Command(async () => await GoToStudents());
        }

        public Command GoToCoursesCommand { get; set; }
        public Command GoToInstructorsCommand { get; set; }
        public Command GoToStudentsCommand { get; set; }

        async Task GoToCourses()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new CoursesPage());
        }

        async Task GoToInstructors()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new InstructorsPage());
        }

        async Task GoToStudents()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new StudentsPage());
        }
    }
}
