using Microsoft.EntityFrameworkCore;
using VictuzMobile.App.ViewModels;
using VictuzMobile.DatabaseConfig;

namespace VictuzMobile.App.Views;

public partial class ActivityDetailsView : ContentPage
{
	ActivityDetailsViewModel ViewModel { get; set; }

    public ActivityDetailsView(DatabaseContext context, int id)
	{
		InitializeComponent();

		ViewModel = new(Navigation);

        ViewModel.Activity = context.Activities
            .Where(a => a.Id == id)
            .Include(a => a.Organiser)
            .Include(a => a.Location)
            .FirstOrDefault();

        BindingContext = ViewModel;
    }
}