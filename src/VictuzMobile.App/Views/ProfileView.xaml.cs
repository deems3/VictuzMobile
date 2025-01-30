using CommunityToolkit.Maui.Views;
using Auth0.OidcClient;
using VictuzMobile.App.Services;
using VictuzMobile.App.ViewModels;

namespace VictuzMobile.App.Views;

public partial class ProfileView : ContentPage
{

    public ProfileViewModel ViewModel { get; set; }

    public ProfileView()
    {
        ViewModel = new(Navigation);
        BindingContext = ViewModel;

        InitializeComponent();

        if (ViewModel.User != null)
        {
            ProfileImageView.Text = ViewModel.User.DisplayName;

            if (ViewModel.User.ProfileImage != null)
            {
                ProfileImageView.ImageSource = ViewModel.User.ProfileImage;
            }
        }
    }

    private void ToggleDisplayName(object sender, EventArgs e)
    {
        DisplayNameLabel.IsVisible = !DisplayNameLabel.IsVisible;
        DisplayNameEntry.IsVisible = !DisplayNameEntry.IsVisible;
        EditDisplayNameBtn.IsVisible = !EditDisplayNameBtn.IsVisible;
        SaveDisplayNameBtn.IsVisible = !SaveDisplayNameBtn.IsVisible;
    }

    private void ToggleEmail(object sender, EventArgs e)
    {
        EmailLabel.IsVisible = !EmailLabel.IsVisible;
        EmailEntry.IsVisible = !EmailEntry.IsVisible;
        EditEmailBtn.IsVisible = !EditEmailBtn.IsVisible;
        SaveEmailBtn.IsVisible = !SaveEmailBtn.IsVisible;
    }
}