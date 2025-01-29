using Microsoft.EntityFrameworkCore;
using VictuzMobile.App.ViewModels;
using VictuzMobile.DatabaseConfig;
using VictuzMobile.App.Services;
using VictuzMobile.DatabaseConfig.Models;

namespace VictuzMobile.App.Views;

public partial class ActivityDetailsView : ContentPage
{
    private readonly AuthService? AuthService;
    private readonly DatabaseContext? DatabaseContext;
    private readonly int activityId;
    ActivityDetailsViewModel ViewModel { get; set; }

    public ActivityDetailsView(int id, bool editmode=false)
	{
        AuthService = IPlatformApplication.Current?.Services.GetRequiredService<AuthService>();
        DatabaseContext = IPlatformApplication.Current?.Services.GetRequiredService<DatabaseContext>();
        activityId = id;

        InitializeComponent();

		ViewModel = new(Navigation, id, editmode);

        BindingContext = ViewModel;

        SetButtonsFormat();

        //if (editmode)
        //{
        //    EnableEditMode();
        //}
    }

    private async void SetButtonsFormat()
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

        if (DatabaseContext is not null)
        {
            int registered = await DatabaseContext.Registrations
                .Where(r => r.ActivityId == activityId && r.UserId == userId)
                .CountAsync();

            if (registered > 0)
            {
                ViewModel.RegisterBtnText = "Uitschrijven";
                ViewModel.RegisterBtnColor = Colors.Red;
            }
        }
    }

    //private void EnableEditMode()
    //{
    //    ActivityTitleLabel.IsVisible = false;
    //    ActivityTitleEntry.IsVisible = true;

    //    ActivityNameLabel.IsVisible = false;
    //    ActivityNameEntry.IsVisible = true;

    //    ActivityDescriptionLabel.IsVisible = false;
    //    ActivityDescriptionEntry.IsVisible = true;

    //    ActivityLocationLabel.IsVisible = false;
    //    ActivityLocationPicker.IsVisible = true;
    //    CreateNewLocationBtn.IsVisible = true;

    //    ActivityMaxRegistrations.IsVisible = false;
    //    ActivityMaxRegistrationsEntry.IsVisible = true;

    //}
}