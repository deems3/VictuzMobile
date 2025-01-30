using CommunityToolkit.Maui.Alerts;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Windows.Input;
using VictuzMobile.App.Services;
using VictuzMobile.DatabaseConfig;
using VictuzMobile.DatabaseConfig.Models;

namespace VictuzMobile.App.ViewModels
{
    public class ActivityQRScanViewModel : INotifyPropertyChanged
    {
        private readonly INavigation _navigation;
        private readonly DatabaseContext _context;
        private readonly int _activityId;


        public event PropertyChangedEventHandler? PropertyChanged;

        public ActivityQRScanViewModel(INavigation navigation, int activityId)
        {
            _navigation = navigation;
            _activityId = activityId;
            _context = IPlatformApplication.Current?.Services.GetRequiredService<DatabaseContext>();
        }

        public async Task HandleQRCodeScanAsync(string qrCodeValue)
        {
            if (!int.TryParse(qrCodeValue, out var userId))
            {
                await ShowAlert("Error", "Invalid QR code. Please scan a valid user ID.");
                return;
            }

            var registration = await _context.Registrations
                .FirstOrDefaultAsync(r => r.ActivityId == _activityId && r.UserId == userId);

            if (registration == null)
            {
                await ShowAlert("Error", "User is not registered for this activity.");
                return;
            }

            if (registration.ArrivalDate != null)
            {
                await ShowAlert("Info", "User has already checked in.");
                return;
            }

            // Update the arrival date
            registration.ArrivalDate = DateTime.Now;
            _context.Registrations.Update(registration);
            await _context.SaveChangesAsync();

            await ShowAlert("Success", "User checked in successfully.");
        }


        private async Task ShowAlert(string title, string message)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, "OK");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}