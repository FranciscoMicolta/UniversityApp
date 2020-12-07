﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.BL.DTOs;
using UniversityApp.BL.Services.Implements;
using UniversityApp.Helpers;
using UniversityApp.Views;
using Xamarin.Forms;

namespace UniversityApp.ViewModels
{
    public class CreateStudentViewModel : BaseViewModel
    {
        private BL.Services.IStudentService studentService;
        private string lastName;
        private string firstMidName;
        private DateTime enrollmentDate;
        private bool isEnabled;
        private bool isRunning;

        public string LastName
        {
            get { return this.lastName; }
            set { this.SetValue(ref this.lastName, value); }
        }

        public string FirstMidName
        {
            get { return this.firstMidName; }
            set { this.SetValue(ref this.firstMidName, value); }
        }

        public DateTime EnrollmentDate
        {
            get { return this.enrollmentDate; }
            set { this.SetValue(ref this.enrollmentDate, value); }
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

        public CreateStudentViewModel()
        {
            this.studentService = new StudentService();
            this.SaveCommand = new Command(async () => await CreateStudent());

            this.IsRunning = false;
            this.IsEnabled = true;
        }

        public Command SaveCommand { get; set; }

        async Task CreateStudent()
        {
            try
            {
                if (string.IsNullOrEmpty(this.LastName) || string.IsNullOrEmpty(this.FirstMidName))
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "You must enter the field all", "Cancel");
                    return;
                }

                this.IsRunning = false;
                this.IsEnabled = true;

                var connection = await studentService.CheckConnection();

                if (!connection)
                {
                    this.IsRunning = false;
                    this.IsEnabled = true;

                    await Application.Current.MainPage.DisplayAlert("Error", "No internet connection", "Cancel");
                    return;
                }

                var studentDTO = new StudentDTO { LastName = this.LastName, FirstMidName = this.FirstMidName, EnrollmentDate = this.EnrollmentDate };
                await studentService.Create(Endpoints.POST_STUDENTS, studentDTO);

                this.IsRunning = false;
                this.IsEnabled = true;

                await Application.Current.MainPage.DisplayAlert("Message", "The process is successful", "Confirm");

                this.LastName = string.Empty;
                this.FirstMidName = string.Empty;
                this.EnrollmentDate = DateTime.UtcNow;
                Application.Current.MainPage = new NavigationPage(new StudentsPage());

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
