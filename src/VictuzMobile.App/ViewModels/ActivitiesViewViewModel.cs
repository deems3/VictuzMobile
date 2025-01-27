using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VictuzMobile.App.Views;
using VictuzMobile.DatabaseConfig;
using VictuzMobile.DatabaseConfig.Models;

namespace VictuzMobile.App.ViewModels
{
    public class ActivitiesViewViewModel : ObservableObject
    {
        public ObservableCollection<Activity> AllActivities { get; set; } = [];
        public ICommand NavigateToActivityCommand { get; }
        private readonly INavigation _navigation;
        private readonly DatabaseContext _context;

        public ActivitiesViewViewModel(INavigation navigation)
        {
            _navigation = navigation;
            NavigateToActivityCommand = new Command<int>(NavigateToActivity);
            _context = IPlatformApplication.Current.Services.GetRequiredService<DatabaseContext>();
        }

        private async void NavigateToActivity(int id)
        {
            await _navigation.PushAsync(new ActivityDetailsView(_context, id));
        }
    }
}
