using VictuzMobile.App.ViewModels;

namespace VictuzMobile.App.Views;

public partial class MainPageView : ContentPage
{
	public MainPageView()
	{
        InitializeComponent();
        GenerateFact();
        BindingContext = new MainPageViewModel();
    }

    private async void GenerateFact()
    {
        FactLabel.Text = await FactAPIVM.GetRandomFact();
    }
}