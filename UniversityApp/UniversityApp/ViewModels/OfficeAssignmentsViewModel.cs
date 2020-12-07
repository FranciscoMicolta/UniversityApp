using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using UniversityApp.BL.DTOs;
using UniversityApp.BL.Services.Implements;
using UniversityApp.Helpers;
using Xamarin.Forms;
namespace UniversityApp.ViewModels
{
    public class OfficeAssignmentsViewModel : BaseViewModel
    {
        private BL.Services.IOfficeAssignmentService officeAssignmentService;
        private ObservableCollection<OfficeAssignmentDTO> officeAssignment;
        private bool isRefreshing;

        public ObservableCollection<OfficeAssignmentDTO> OfficeAssignment
        {
            get { return this.officeAssignment; }
            set { this.SetValue(ref this.officeAssignment, value); }
        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public OfficeAssignmentsViewModel()
        {
            this.officeAssignmentService = new OfficeAssignmentService();
            this.RefreshCommand = new Command(async () => await GetOfficeAssignment());
            this.RefreshCommand.Execute(null);
        }

        public Command RefreshCommand { get; set; }

        async Task GetOfficeAssignment()
        {
            try
            {
                this.IsRefreshing = true;
                var connection = await officeAssignmentService.CheckConnection();
                if (!connection)
                {
                    this.IsRefreshing = false;
                    await Application.Current.MainPage.DisplayAlert("Error", "No connection internet", "Cancel");
                }
                var listOfficeAssignment = await officeAssignmentService.GetAll(Endpoints.GET_OFFICEASSIGNMENTS);
                this.OfficeAssignment = new ObservableCollection<OfficeAssignmentDTO>(listOfficeAssignment);
                this.IsRefreshing = false;
            }
            catch (Exception ex)
            {
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Cancel");
            }
        }
    }
}
