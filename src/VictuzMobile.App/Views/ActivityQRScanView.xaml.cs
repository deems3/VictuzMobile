namespace VictuzMobile.App.Views;
using ZXing.Net.Maui.Controls;

public partial class ActivityQRScanView : ContentPage
{
	public ActivityQRScanView(int id)
	{
		InitializeComponent();
        cameraBarcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
        {
            Formats = ZXing.Net.Maui.BarcodeFormat.QrCode,
        };
    }

    private void cameraBarcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        {
            var first = e.Results?.FirstOrDefault();

            if (first is null)
                return;
            Dispatcher.DispatchAsync(async () =>
            {
                await DisplayAlert("User scanned, their ID is:", first.Value, "OK");
            });
        }
    }
}