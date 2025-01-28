using CommunityToolkit.Maui.Views;

namespace VictuzMobile.App.Views;

public partial class ProfileView : ContentPage
{
    public ProfileView()
    {
        AvatarView avatarView = new()
        {
            Text = "PFP",
            BackgroundColor = Colors.Black,
            BorderColor = Color.FromArgb("#0F8390"),
            BorderWidth = 7,
            CornerRadius = 1000,
            HeightRequest = 300,
            WidthRequest = 300,
            ImageSource = "placeholderpfp.png"
        };
        Content = avatarView;

        InitializeComponent();
    }
}
