using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VictuzMobile.App.Views;
using VictuzMobile.DatabaseConfig.Models;

namespace VictuzMobile.App.ViewModels
{
    class ActivityDetailsViewModel
    {
        private readonly INavigation _navigation;
        private ICommand NavigateToManagePageCommand { get; }
        private ICommand RegisterForActivityCommand { get; }
        public Activity? Activity { get; set; }

        public ActivityDetailsViewModel(INavigation navigation)
        {
            _navigation = navigation;
            NavigateToManagePageCommand = new Command<int>(NavigateToManagePage);
            RegisterForActivityCommand = new Command(RegisterForActivity);
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
            // send back result to user by pop-up message.
        }
    }
}
