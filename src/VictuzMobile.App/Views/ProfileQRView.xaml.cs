namespace VictuzMobile.App.Views;
using VictuzMobile.App.Services;
using VictuzMobile.DatabaseConfig.Models;


public partial class ProfileQRView : ContentPage
{
    private string QrCodeString;
    public ProfileQRView()
	{
        InitializeComponent();
        SetQRCode();
	}


    private async void SetQRCode()
    {
        var user = SecureStorageService.GetCurrentUserId();
        if (user != null)
        {
            QrCodeString = user.Id.ToString();
            QrCodeGenerator.Value = QrCodeString;
        }
        else
        {
            await DisplayAlert("Not Logged In", "You need to log in before viewing your QR code.", "OK");
        }
    }
}