namespace VictuzMobile.App.Views;
using VictuzMobile.App.Services;
using VictuzMobile.DatabaseConfig.Models;


public partial class ProfileQRView : ContentPage
{
    private string QrCodeString;
    public ProfileQRView(int id)
	{
        InitializeComponent();
        QrCodeString = id.ToString();
        SetQRCode(id);
	}


    private void SetQRCode(int id)
    {
        QrCodeGenerator.Value = QrCodeString;
    }
}