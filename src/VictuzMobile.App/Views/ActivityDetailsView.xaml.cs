using Microsoft.EntityFrameworkCore;
using VictuzMobile.App.ViewModels;
using VictuzMobile.DatabaseConfig;
using VictuzMobile.App.Services;
using VictuzMobile.DatabaseConfig.Models;
using Plugin.LocalNotification;

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

        if (editmode)
        {
            EnableEditMode();
        }
    }

    private async void SetButtonsFormat()
    {
        int? userId = await SecureStorageService.GetCurrentUserId();
        User? user = await AuthService?.GetUser((int)userId);

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

    private void EnableEditMode()
    {
        ActivityNameLabel.Text = "Activiteit naam";
        ActivityNameEntry.IsVisible = true;

        ActivityDescriptionLabel.Text = "Beschrijving";
        ActivityDescriptionEntry.IsVisible = true;

        ActivityOrganiserLabel.IsVisible = false;

        ActivityLocationLabel.Text = "Locatie";
        ActivityLocationPicker.IsVisible = true;
        CreateNewLocationBtn.IsVisible = true;

        ActivityMaxRegistrations.Text = "Max deelnemers";
        ActivityMaxRegistrationsEntry.IsVisible = true;

        ManageActivityBtn.IsVisible = false;
        SaveActivityBtn.IsVisible = true;

        RegisterForActivityBtn.IsVisible = false;
    }

    private void OnRegisterClicked(object sender, EventArgs e)
    {
        var request = new NotificationRequest
        {
            NotificationId = 100,
            Title = "Je bent ingeschreven.",
            Subtitle = "Victuz",
            Description = "Je hebt je succesvol ingeschreven voor een activiteit!",
            BadgeNumber = 1,
            Schedule = new NotificationRequestSchedule
            {
                NotifyTime = DateTime.Now.AddMicroseconds(1),
                NotifyRepeatInterval = TimeSpan.FromDays(1),
            }
        };
        LocalNotificationCenter.Current.Show(request);
    }
}