using System;
using System.Threading.Tasks;
using UniversityApp.BL.DTOs;
using UniversityApp.BL.Services.Implements;
using UniversityApp.Helpers;
using Xamarin.Forms;

namespace UniversityApp.ViewModels
{
    public class EditInstructorViewModel : BaseViewModel
    {
        private BL.Services.IInstructorService instructorService;
        private InstructorDTO instructor;

        private bool isEnabled;
        private bool isRunning;

        public InstructorDTO Instructor
        {
            get { return this.instructor; }
            set { this.SetValue(ref this.instructor, value); }
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { this.SetValue(ref this.isEnabled, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { this.SetValue(ref this.isRunning, value); }
        }

        public EditInstructorViewModel(InstructorDTO instructor)
        {
            this.instructor = instructor;

            this.instructorService = new InstructorService();
            SaveCommand = new Command(async () => await EditInstructor());

            this.IsRunning = false;
            this.IsEnabled = true;
        }

        public Command SaveCommand { get; set; }

        async Task EditInstructor()
        {
            try
            {
                if (string.IsNullOrEmpty(this.Instructor.LastName) || string.IsNullOrEmpty(this.Instructor.FirstMidName))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "You must enter all the fields", "Cancel");
                    return;
                }

                this.IsRunning = false;
                this.IsEnabled = true;

                var connection = await instructorService.CheckConnection();
                if (!connection)
                {
                    this.IsRunning = false;
                    this.IsEnabled = true;

                    await Application.Current.MainPage.DisplayAlert("Error", "No internet connection", "Cancel");
                    return;
                }

                var instructorDTO = new InstructorDTO { ID = this.Instructor.ID, LastName = this.Instructor.LastName, FirstMidName = this.Instructor.FirstMidName, HireDate = this.Instructor.HireDate };
                await instructorService.Update(Endpoints.PUT_INSTRUCTORS, this.Instructor.ID, instructorDTO);

                this.IsRunning = false;
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert("Message", "The process is sucessfull", "Confirm");

                this.Instructor.LastName = string.Empty;
                this.Instructor.FirstMidName = string.Empty;

                await Application.Current.MainPage.Navigation.PopAsync();

            }
            catch (Exception ex)
            {   
                this.IsRunning = false;
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Cancel");
            }
        } 
    }
}
