using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using UniversityApp.BL.DTOs;
using UniversityApp.BL.Services.Implements;
using UniversityApp.Helpers;
using Xamarin.Forms;

namespace UniversityApp.ViewModels
{
    public class InstructorsViewModel : BaseViewModel
    {
        private BL.Services.IInstructorService instructorService;
        private ObservableCollection<InstructorItemViewModel> instructor;
        private bool isRefreshing;
        private string filter;

        public List<InstructorItemViewModel> AllInstructor { get; set; }

        public string Filter
        {
            get { return this.filter; }
            set 
            { 
                this.SetValue(ref this.filter, value);
                this.GetInstructorByName();
            }
        }


        public ObservableCollection<InstructorItemViewModel> Instructor
        {
            get { return this.instructor; }
            set { this.SetValue(ref this.instructor, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public InstructorsViewModel()
        {
            instance = this;
            this.instructorService = new InstructorService();
            this.RefreshCommand = new Command(async () => await GetInstructor());
            this.RefreshCommand.Execute(null);
        }

        private static InstructorsViewModel instance;
        public static InstructorsViewModel GetInstance()
        {
            if (instance == null)
                return new InstructorsViewModel();

            return instance;
        }

        public Command RefreshCommand { get; set; }

        async Task GetInstructor()
        {
            try
            {
                this.IsRefreshing = true;
                var connection = await instructorService.CheckConnection();

                if (!connection)
                {
                    this.IsRefreshing = false;
                    await Application.Current.MainPage.DisplayAlert("Error", "No connection internet", "Cancel");
                    return;
                }

                var listInstructors = (await instructorService.GetAll(Endpoints.GET_INSTRUCTORS)).Select(x => ToInstructorItemViewModel(x));
                this.AllInstructor = listInstructors.ToList();
                this.Instructor = new ObservableCollection<InstructorItemViewModel>(listInstructors);
                this.IsRefreshing = false;
            }
            catch (Exception ex)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Cancel");
            }
        }

        private InstructorItemViewModel ToInstructorItemViewModel(InstructorDTO instructorDTO) => new InstructorItemViewModel()
        {
            ID = instructorDTO.ID,
            LastName = instructorDTO.LastName,
            FirstMidName = instructorDTO.FirstMidName,
            HireDate = instructorDTO.HireDate
        };

        public void GetInstructorByName()
        {
            var listInstructors = this.AllInstructor;
            if (!string.IsNullOrEmpty(this.Filter))
                listInstructors = listInstructors.Where(x => x.FullName.ToLower().Contains(this.Filter.ToLower())).ToList();

            this.Instructor = new ObservableCollection<InstructorItemViewModel>(listInstructors);
        }
    }
}
