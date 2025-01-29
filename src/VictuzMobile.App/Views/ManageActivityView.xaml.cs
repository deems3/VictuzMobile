using VictuzMobile.App.ViewModels;

namespace VictuzMobile.App.Views;

public partial class ManageActivityView : ContentPage
{
	public ManageActivityViewModel ViewModel { get; set; }

	private int activityId;

    public ManageActivityView(int id)
	{
		activityId = id;

		InitializeComponent();

		ViewModel = new ManageActivityViewModel(Navigation, id);
        BindingContext = ViewModel;
    }
}