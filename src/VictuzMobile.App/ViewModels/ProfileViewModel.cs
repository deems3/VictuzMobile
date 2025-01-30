using Auth0.OidcClient;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VictuzMobile.App.Services;
using VictuzMobile.App.Views;
using VictuzMobile.DatabaseConfig;
using VictuzMobile.DatabaseConfig.Models;

namespace VictuzMobile.App.ViewModels
{
    public class ProfileViewModel : INotifyPropertyChanged
    {
        public User? User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand DeleteAccountCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand ShowQRCommand { get; }
        public ICommand ShowOwnSuggestionsCommand { get; }
        public ICommand ResetPasswordCommand { get; }
        public ICommand SaveUserChangesCommand { get; }
        public ICommand TakeProfilePictureCommand { get; }

        private readonly DatabaseContext? DatabaseContext;
        private readonly INavigation _navigation;
        private User? _user;
        private int? userId;

        public ProfileViewModel(INavigation navigation)
        {
            DatabaseContext = IPlatformApplication.Current?.Services.GetRequiredService<DatabaseContext>();
            _navigation = navigation;

            DeleteAccountCommand = new Command(async () => await DeleteAccount());
            LogoutCommand = new Command(async () => await Logout());
            ShowQRCommand = new Command(async () => await ShowQR());
            ShowOwnSuggestionsCommand = new Command(async () => await ShowOwnSuggestions());
            ResetPasswordCommand = new Command(async () => await ResetPassword());
            SaveUserChangesCommand = new Command(async () => await SaveUserChanges());
            TakeProfilePictureCommand = new Command(async () => await TakeProfilePicture());

            GetUser();
        }

        private async Task GetUser()
        {
            if (DatabaseContext == null)
            {
                var toast = Toast.Make("Failed to retrieve database", textSize: 20);
                await toast.Show();
                return;
            }

            userId = await SecureStorageService.GetCurrentUserId();

            if (userId == null)
            {
                var toast = Toast.Make("Failed to retrieve userid", textSize: 20);
                await toast.Show();
                return;
            }

            User = await DatabaseContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (User == null)
            {
                var toast = Toast.Make("Failed to retrieve user", textSize: 20);
                await toast.Show();
                return;
            }
        }

        private async Task DeleteAccount()
        {
            bool confirm = await Application.Current?.MainPage.DisplayAlert("Bevestig account verwijdering", "Weet je zeker dat je je account wilt verwijderen? Je kan geen account registeren via de app.", "Ja", "Nee");
            if (confirm && DatabaseContext is not null && User is not null)
            {
                DatabaseContext.Users.Remove(User);
                await DatabaseContext.SaveChangesAsync();
                Logout();
            }
        }

        private async Task Logout()
        {
            var auth0Client = IPlatformApplication.Current?.Services.GetRequiredService<Auth0Client>();
            var authService = IPlatformApplication.Current?.Services.GetRequiredService<AuthService>();

            SecureStorageService.ClearCurrentUser();

            await _navigation.PopToRootAsync();
            Application.Current.Windows[0].Page = new MainPage(auth0Client, authService);
        }

        private async Task ShowQR()
        {
            if (userId == null)
            {
                var toast = Toast.Make("Failed to retrieve userid", textSize: 20);
                await toast.Show();
                return;
            }

            await _navigation.PushAsync(new ProfileQRView((int)userId));
        }

        private async Task ShowOwnSuggestions()
        {
            var toast = Toast.Make("Not implemented yet", textSize: 20);
            await toast.Show();
        }

        private async Task ResetPassword()
        {
            var toast = Toast.Make("Not implemented yet", textSize: 20);
            await toast.Show();
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task SaveUserChanges()
        {
            IToast toast;

            if (DatabaseContext == null || User == null)
            {
                toast = Toast.Make("Failed to retrieve database or user", textSize: 20);
                await toast.Show();
                return;
            }

            DatabaseContext.Users.Update(User);
            await DatabaseContext.SaveChangesAsync();
            OnPropertyChanged(nameof(User));

            toast = Toast.Make("Saved", textSize: 20);
            await toast.Show();
        }

        private async Task TakeProfilePicture()
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                if (photo == null)
                    return;

                var filePath = Path.Combine(FileSystem.AppDataDirectory, photo.FileName);

                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(filePath))
                    await stream.CopyToAsync(newStream);

                if (User == null)
                {
                    throw new Exception("User is null");
                }

                User.ProfileImage = filePath;
                await SaveUserChanges();

            }
            catch (Exception ex)
            {
                var toast = Toast.Make("Failed to save picture", textSize: 20);
                await toast.Show();
            }

        }
    }
}
