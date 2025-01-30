using System.ComponentModel;
using System.Runtime.CompilerServices;
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
                if (IsAutomaticThemeEnabled) // when automatic theme is enabled, dark mode is always disabled.
                {
                    _IsDarkModeEnabled = false;
                } else
                {
                    _IsDarkModeEnabled = value;
                    Application.Current.UserAppTheme = _IsDarkModeEnabled ? AppTheme.Dark : AppTheme.Light;
                }

                OnPropertyChanged();
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

                if (_IsAutomaticThemeEnabled && _IsDarkModeEnabled) // If automatic theme is enabled, disable dark mode
                {
                    IsDarkModeEnabled = false;
                }

                // if automatic theme is enabled, set the theme to unspecified otherwise light, since dark mode is always disabled while automatic theme is enabled
                Application.Current.UserAppTheme = _IsAutomaticThemeEnabled ? AppTheme.Unspecified : AppTheme.Light;

                Task.Run(() => SecureStorageService.SetAutomaticThemeMode(_IsAutomaticThemeEnabled));
            }
        }

        public bool IsPushNotificationsEnabled
        {
            get => _IsPushNotificationsEnabled;
            set
            {
                _IsPushNotificationsEnabled = value;
                OnPropertyChanged();

                Task.Run(() => SecureStorageService.SetPushNotifications(value));
            }
        }

        private bool _IsDarkModeEnabled;
        private bool _IsAutomaticThemeEnabled;
        private bool _IsPushNotificationsEnabled;

        public SettingsViewModel()
        {
            GetStates();
        }

        private async void GetStates()
        {
            IsAutomaticThemeEnabled = await SecureStorageService.GetAutomaticThemeMode();
            IsDarkModeEnabled = await SecureStorageService.GetDarkMode();
            IsPushNotificationsEnabled = await SecureStorageService.GetPushNotifications();
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
