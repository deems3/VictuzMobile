using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictuzMobile.DatabaseConfig.Models;

namespace VictuzMobile.App.ViewModels
{
    public class ActivitiesViewViewModel : ObservableObject
    {
        public ObservableCollection<Activity> AllActivities { get; set; } = [];
    }
}
