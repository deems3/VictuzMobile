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
    class ManageActivityViewModel
    {
        public ICommand EditActivityCommand;
        public ICommand RegistrationListCommand;
        public ICommand SendMessageCommand;

        private int activityId;

        private readonly DatabaseContext? DatabaseContext;
        private readonly INavigation _navigation;

        public ManageActivityViewModel(INavigation navigation, int id)
        {
            activityId = id;
            EditActivityCommand = new Command(EditActivity);
            RegistrationListCommand = new Command(RegistrationList);
            SendMessageCommand = new Command(SendMessage);

            DatabaseContext = IPlatformApplication.Current?.Services.GetRequiredService<DatabaseContext>();
            _navigation = navigation;
        }

        private async void EditActivity()
        {
            // navigate back to the activity details page with edit mode enabled
            await _navigation.PushAsync(new ActivityDetailsView(activityId, true));
        }

        private async void RegistrationList()
        {
            // retrieve registrations from database
            // open modalpage with registrations
        }

        private async void SendMessage()
        {
            // open a prompt to send a message
            // send message to all registered users by push notification (only for current user since this is a demo)
        }
    }
}
