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
        public Activity? Activity { get; set; }

        public ActivityDetailsViewModel(INavigation navigation)
        {
            _navigation = navigation;
            NavigateToManagePageCommand = new Command<int>(NavigateToManagePage);
        }

        private async void NavigateToManagePage(int id)
        {
            await _navigation.PushAsync(new ManageActivityView(id));
        }
    }
}
