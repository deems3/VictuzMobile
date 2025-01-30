namespace VictuzMobile.App.Views;
using ZXing.Net.Maui.Controls;
using VictuzMobile.App.ViewModels;

public partial class ActivityQRScanView : ContentPage
{
    private readonly ActivityQRScanViewModel _viewModel;

    public ActivityQRScanView(int activityId)
    {
        InitializeComponent();
        _viewModel = new ActivityQRScanViewModel(Navigation, activityId);
        BindingContext = _viewModel;

        cameraBarcodeReader.Options = new ZXing.Net.Maui.BarcodeReaderOptions
        {
            Formats = ZXing.Net.Maui.BarcodeFormat.QrCode,
        };
    }

    private void cameraBarcodeReader_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
    {
        var first = e.Results?.FirstOrDefault();

        if (first is null)
            return;

        Dispatcher.DispatchAsync(async () =>
        {
            var qrCodeValue = first.Value;
            await _viewModel.HandleQRCodeScanAsync(qrCodeValue);
        });
    }
}