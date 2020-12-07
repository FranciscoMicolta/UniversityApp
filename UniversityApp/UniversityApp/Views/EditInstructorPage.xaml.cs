using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniversityApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditInstructorPage : ContentPage
    {
        public EditInstructorPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}