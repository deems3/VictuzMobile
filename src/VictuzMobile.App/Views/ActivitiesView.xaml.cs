using VictuzMobile.App.ViewModels;
using VictuzMobile.DatabaseConfig;

namespace VictuzMobile.App.Views;

public partial class ActivitiesView : ContentPage
{
    public ActivitiesViewViewModel ViewModel { get; set; }
    public ActivitiesView(DatabaseContext context)
    {
        InitializeComponent();

        ViewModel = new ActivitiesViewViewModel(Navigation);

        BindingContext = ViewModel;

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await ViewModel.PopulateRegisteredActivities();

        NoRegisteredActivitiesLabel.IsVisible = ViewModel.RegisteredActivities.Count == 0;
    }

    private void YourActivityFilterButton_Clicked(object sender, EventArgs e)
    {

    }

    private void AllActivityFilterButton_Clicked(object sender, EventArgs e)
    {

    }

    private void SuggestionActivityFilterButton_Clicked(object sender, EventArgs e)
    {

    }

    private void QRScanBtn_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ActivityQRScanView());
    }
}