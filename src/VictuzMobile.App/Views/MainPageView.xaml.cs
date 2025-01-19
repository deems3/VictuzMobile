using VictuzMobile.App.ViewModels;

namespace VictuzMobile.App.Views;

public partial class MainPageView : ContentPage
{
	public MainPageView()
	{
		InitializeComponent();
		BindingContext = new MainPageViewModel();
    }
}