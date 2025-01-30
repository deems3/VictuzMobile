using VictuzMobile.App.Services;
using VictuzMobile.App.ViewModels;
using VictuzMobile.DatabaseConfig.Models;

namespace VictuzMobile.App.Views;

public partial class SuggestionView : ContentPage
{
    private AuthService? AuthService;

    public SuggestionsViewModel ViewModel { get; set; }
    public SuggestionView(int id, bool editmode=false)
	{
        AuthService = IPlatformApplication.Current?.Services.GetRequiredService<AuthService>();

        ViewModel = new SuggestionsViewModel(Navigation, id);
        BindingContext = ViewModel;

        InitializeComponent();

        ApplyUserPermissions();

        if (editmode)
        {
            EnableEditMode();
        }
    }

    private void EnableEditMode()
    {
        SuggestionNameLabel.Text = "Activiteit naam";
        SuggestionNameEntry.IsVisible = true;

        SuggestionDescriptionLabel.Text = "Beschrijving";
        SuggestionDescriptionEntry.IsVisible = true;

        SuggestionOrganiserLabel.IsVisible = false;

        SuggestionLocationLabel.Text = "Locatie";
        SuggestionLocationPicker.IsVisible = true;
        CreateNewLocationBtn.IsVisible = true;

        SuggestionMaxRegistrations.Text = "Max deelnemers";
        SuggestionMaxRegistrationsEntry.IsVisible = true;

        LikeStackLayout.IsVisible = false;

        EditSuggestionBtn.IsVisible = false;
        SaveSuggestionBtn.IsVisible = true;
        RefreshSuggestionBtn.IsVisible = false;
    }

    private async void ApplyUserPermissions()
    {
        int? userId = await SecureStorageService.GetCurrentUserId();
        User? user = await AuthService?.GetUser((int)userId);

        if (user != null && userId != null && (user.Role == UserRole.Admin || ViewModel.Suggestion?.OrganiserId == userId))
        {
            EditSuggestionBtn.IsVisible = true;
            RefreshSuggestionBtn.IsVisible = true;
        }
    }
}