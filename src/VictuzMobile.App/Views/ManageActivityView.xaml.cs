using VictuzMobile.App.ViewModels;

namespace VictuzMobile.App.Views;

public partial class ManageActivityView : ContentPage
{
	ManageActivityViewModel ViewModel { get; set; }

	private int activityId;

    public ManageActivityView(int id)
	{
		activityId = id;

		InitializeComponent();

		ViewModel = new(Navigation, id);
        BindingContext = ViewModel;
    }
}