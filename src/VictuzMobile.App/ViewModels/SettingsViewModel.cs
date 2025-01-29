using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VictuzMobile.App.Services;

namespace VictuzMobile.App.ViewModels
{
    public class SettingsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public bool IsDarkModeEnabled
        {
            get => _IsDarkModeEnabled;
            set
            {
                _IsDarkModeEnabled = _IsAutomaticThemeEnabled ? false : value; // always disable dark mode if automatic theme is enabled otherwise set the value
                OnPropertyChanged();

                Application.Current.UserAppTheme = _IsDarkModeEnabled ? AppTheme.Dark : AppTheme.Light;
                Task.Run(() => SecureStorageService.SetDarkMode(_IsDarkModeEnabled)); // Save the state to secure storage in a background thread so it can still be run async.
            }
        }

        public bool IsAutomaticThemeEnabled
        {
            get => _IsAutomaticThemeEnabled;
            set
            {
                _IsAutomaticThemeEnabled = value;
                OnPropertyChanged();

                if (_IsAutomaticThemeEnabled) // If automatic theme is enabled, disable dark mode
                {
                    IsDarkModeEnabled = false;
                }

                // if automatic theme is enabled, set the theme to unspecified otherwise light, since dark mode is always disabled while automatic theme is enabled
                Application.Current.UserAppTheme = _IsAutomaticThemeEnabled ? AppTheme.Unspecified: AppTheme.Light;

                Task.Run(() => SecureStorageService.SetAutomaticThemeMode(_IsAutomaticThemeEnabled));
            }
        }

        private bool _IsDarkModeEnabled;
        private bool _IsAutomaticThemeEnabled;

        public SettingsViewModel()
        {
            GetStates();
        }

        private async void GetStates()
        {
            IsDarkModeEnabled = await SecureStorageService.GetDarkMode();
            IsAutomaticThemeEnabled = await SecureStorageService.GetAutomaticThemeMode();
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
