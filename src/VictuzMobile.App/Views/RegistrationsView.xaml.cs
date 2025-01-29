using VictuzMobile.App.ViewModels;

namespace VictuzMobile.App.Views;

public partial class RegistrationsView : ContentPage
{
    public RegistrationsViewModel ViewModel { get; set; }

	public RegistrationsView(int id)
	{
		InitializeComponent();

        ViewModel = new(id);
        BindingContext = ViewModel;
    }

    private async void CloseBtn_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }
}