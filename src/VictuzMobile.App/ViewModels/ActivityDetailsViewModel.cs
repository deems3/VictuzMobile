using CommunityToolkit.Maui.Alerts;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        public ICommand CreateNewLocationCommand { get; }
        public ICommand SaveActivityCommand { get; }
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

        public Color? RegisterBtnColor
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

        public IList<DatabaseConfig.Models.Location> ActivityLocations { get; set; } // not observable at the moment.

        private DatabaseContext? _context;
        private readonly INavigation _navigation;
        private string _RegisterBtnText = "Inschrijven";
        private Color? _RegisterBtnColor = (Color?)Application.Current?.Resources["YellowBlue"];
        private int activityId;

        public ActivityDetailsViewModel(INavigation navigation, int id, bool _editmode=false)
        {
            _context = IPlatformApplication.Current?.Services.GetRequiredService<DatabaseContext>();
            _navigation = navigation;
            NavigateToManagePageCommand = new Command<int>(NavigateToManagePage);
            RegisterForActivityCommand = new Command(RegisterForActivity);
            CreateNewLocationCommand = new Command(CreateNewLocation);
            SaveActivityCommand = new Command(SaveActivity);

            activityId = id;

            GetActivityDetails();
        }

        private async void GetActivityDetails()
        {
            Activity = await _context.Activities
                .Where(a => a.Id == activityId)
                .Include(a => a.Organiser)
                .Include(a => a.Location)
                .Include(a => a.Registration)
                .FirstOrDefaultAsync();

            ActivityLocations = await _context.Locations.ToListAsync();
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
            if (Activity == null || userId == null || _context == null)
            {
                return;
            }

            var registration = await _context.Registrations
                .FirstOrDefaultAsync(r => r.ActivityId == Activity.Id && r.UserId == userId);

            if (registration != null)
            {
                _context.Registrations.Remove(registration);
                await _context.SaveChangesAsync();

                RegisterBtnText = "Inschrijven";
                RegisterBtnColor = (Color?)Application.Current?.Resources["YellowBlue"];

                await Application.Current.MainPage.DisplayAlert("Success", "You have unregistered for this activity.", "OK");
            }
            else
            {
                _context.Registrations.Add(new Registration()
                {
                    UserId = (int)userId,
                    ActivityId = Activity.Id
                });

                await _context.SaveChangesAsync();

                RegisterBtnText = "Uitschrijven";
                RegisterBtnColor = Colors.Red;

                await Application.Current.MainPage.DisplayAlert("Success", "You have successfully registered for this activity.", "OK");
            }
        }

        private async void CreateNewLocation()
        {
            // show modal page to create a new location
            // not implemented for now.
            await Application.Current.MainPage.DisplayAlert("ERROR", "This functionality is currently not implemented.", "OK");
        }

        private async void SaveActivity()
        {
            if (_context == null || Activity == null)
            {
                return;
            }

            _context.Activities.Update(Activity);
            await _context.SaveChangesAsync();

            var toast = Toast.Make("Activity saved successfully.", textSize:20);
            await toast.Show();
            await _navigation.PopModalAsync();
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
