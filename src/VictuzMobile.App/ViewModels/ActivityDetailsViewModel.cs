using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VictuzMobile.App.Services;
using VictuzMobile.App.Views;
using VictuzMobile.DatabaseConfig;
using VictuzMobile.DatabaseConfig.Models;

namespace VictuzMobile.App.ViewModels
{
    class ActivityDetailsViewModel : INotifyPropertyChanged
    {
        public ICommand NavigateToManagePageCommand { get; }
        public ICommand RegisterForActivityCommand { get; }
        public Activity? Activity { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public string RegisterBtnText
        {
            get
            {
                return _RegisterBtnText;
            }
            set
            {
                _RegisterBtnText = value;
                OnPropertyChanged(nameof(RegisterBtnText));
            }
        }

        public Color RegisterBtnColor
        {
            get
            {
                return _RegisterBtnColor;
            }
            set
            {
                _RegisterBtnColor = value;
                OnPropertyChanged(nameof(RegisterBtnColor));
            }
        }

        private DatabaseContext? _context;
        private readonly INavigation _navigation;
        private string _RegisterBtnText = "Inschrijven";
        private Color? _RegisterBtnColor = (Color?)Application.Current?.Resources["YellowBlue"];

        public ActivityDetailsViewModel(INavigation navigation, int id)
        {
            _context = IPlatformApplication.Current?.Services.GetRequiredService<DatabaseContext>();
            _navigation = navigation;
            NavigateToManagePageCommand = new Command<int>(NavigateToManagePage);
            RegisterForActivityCommand = new Command(RegisterForActivity);


            Activity = _context?.Activities
                .Where(a => a.Id == id)
                .Include(a => a.Organiser)
                .Include(a => a.Location)
                .Include(a => a.Registration)
                .FirstOrDefault();
        }

        private async void NavigateToManagePage(int id)
        {
            await _navigation.PushAsync(new ManageActivityView(id));
        }

        private async void RegisterForActivity()
        {
            // check if user is already registered for activity.
            //  if not, register for activity.
            //  if yes, unregister for activity.
            // send back result to user by pop-up message

            var userId = await SecureStorageService.GetCurrentUserId();
            if (Activity == null || userId == null)
            {
                return;
            }

            foreach (var registration in Activity?.Registration)
            {
                if (registration.UserId == userId)
                {
                    _context?.Registrations.Remove(registration);
                    await _context.SaveChangesAsync();

                    RegisterBtnText = "Inschrijven";
                    RegisterBtnColor = (Color?)Application.Current?.Resources["YellowBlue"];

                    // Couldn't find a way to display an alert without using the obsolete Application.Current.Mainpage method. Only other way was to create an entire new service.
                    await Application.Current.MainPage.DisplayAlert("Success", "You have unregistered for this activity.", "OK");
                    return;
                }
            }

            _context?.Registrations.Add(new Registration()
            {
                UserId = (int)userId,
                ActivityId = Activity.Id
            });

            await _context.SaveChangesAsync();

            RegisterBtnText = "Uitschrijven";
            RegisterBtnColor = Colors.Red;

            await Application.Current.MainPage.DisplayAlert("Success", "You have successfully registered for this activity.", "OK");
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
