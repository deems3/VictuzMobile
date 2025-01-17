using VictuzMobile.ViewModels;

namespace VictuzMobile.Views;

public partial class MainPageView : ContentPage
{
	public MainPageView()
	{
		InitializeComponent();
		BindingContext = new MainPageViewModel();
    }
}