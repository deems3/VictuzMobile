using Microsoft.EntityFrameworkCore;
using VictuzMobile.App.ViewModels;
using VictuzMobile.DatabaseConfig;
using VictuzMobile.App.Services;
using VictuzMobile.DatabaseConfig.Models;

namespace VictuzMobile.App.Views;

public partial class ActivityDetailsView : ContentPage
{
    private readonly AuthService? AuthService;
    ActivityDetailsViewModel ViewModel { get; set; }

    public ActivityDetailsView(int id)
	{
        AuthService = IPlatformApplication.Current?.Services.GetRequiredService<AuthService>();

        InitializeComponent();

		ViewModel = new(Navigation, id);

        BindingContext = ViewModel;

        SetButtonsVisibility();
    }

    private async void SetButtonsVisibility()
    {
        int? userId = await SecureStorageService.GetCurrentUserId();
        User? user = AuthService?.GetUser((int)userId);

        if (userId is null || user is null)
        {
            await DisplayAlert("ERROR", "Failed to retrieve logged in user, Registration and Manage buttons disabled.", "OK");
            ManageActivityBtn.IsVisible = false;
            ManageActivityBtn.IsEnabled = false;
            RegisterForActivityBtn.IsVisible = false;
            RegisterForActivityBtn.IsEnabled = false;
            return;
        }

        if (ViewModel.Activity?.Organiser.Id == userId)
        {
            ManageActivityBtn.IsVisible = true;
            ManageActivityBtn.IsEnabled = true;
            RegisterForActivityBtn.IsVisible = false;
            RegisterForActivityBtn.IsEnabled = false;
        }

        if (user.Role == UserRole.Admin)
        {
            ManageActivityBtn.IsVisible = true;
            ManageActivityBtn.IsEnabled = true;
        }
    }
}