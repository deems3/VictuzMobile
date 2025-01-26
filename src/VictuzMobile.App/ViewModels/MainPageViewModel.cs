using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using VictuzMobile.DatabaseConfig.Models;

namespace VictuzMobile.App.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        public ObservableCollection<Activity> UpcomingActivities { get; set; } = [];

        [ObservableProperty]
        public string fact = "Generating fact...";
    }
}
