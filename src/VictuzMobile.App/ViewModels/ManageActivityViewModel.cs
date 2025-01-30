using CommunityToolkit.Maui.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VictuzMobile.App.Views;
using VictuzMobile.DatabaseConfig;

namespace VictuzMobile.App.ViewModels
{
    public class ManageActivityViewModel
    {
        public ICommand EditActivityCommand { get; }
        public ICommand RegistrationListCommand { get; }
        public ICommand SendMessageCommand { get; }
        public ICommand ScanQRCodeCommand { get; }

        private int activityId;

        private readonly DatabaseContext? DatabaseContext;
        private readonly INavigation _navigation;

        public ManageActivityViewModel(INavigation navigation, int id)
        {
            activityId = id;
            EditActivityCommand = new Command(EditActivity);
            RegistrationListCommand = new Command(RegistrationList);
            SendMessageCommand = new Command(SendMessage);
            ScanQRCodeCommand = new Command(ScanQRCode);

            DatabaseContext = IPlatformApplication.Current?.Services.GetRequiredService<DatabaseContext>();
            _navigation = navigation;
        }

        private async void EditActivity()
        {
            // navigate back to the activity details page with edit mode enabled
            await _navigation.PushModalAsync(new ActivityDetailsView(activityId, true));
        }

        private async void RegistrationList()
        {
            // retrieve registrations from database
            // open modalpage with registrations

            await _navigation.PushModalAsync(new RegistrationsView(activityId));
        }

        private async void SendMessage()
        {
            // open a prompt to send a message
            // send message to all registered users by push notification (only for current user since this is a demo)

            string message = await Application.Current.MainPage.DisplayPromptAsync("Verstuur bericht", "Vul hier je bericht in.");

            await Application.Current.MainPage.DisplayAlert("Bericht van organisator:", message, "OK");
        }

        private async void ScanQRCode()
        {
            await _navigation.PushAsync(new ActivityQRScanView(activityId));
        }
    }
}
