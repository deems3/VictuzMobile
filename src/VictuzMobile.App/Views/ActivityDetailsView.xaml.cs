using Microsoft.EntityFrameworkCore;
using VictuzMobile.App.ViewModels;
using VictuzMobile.DatabaseConfig;
using Plugin.LocalNotification;

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

    private void RegisterForActivity_Clicked(object sender, EventArgs e)
    {
        var request = new NotificationRequest
        {
            NotificationId = 100,
            Title = "Registratie",
            Description = "Je bent succesvol geregistreerd voor deze activiteit",
            Schedule = new NotificationRequestSchedule { NotifyTime = DateTime.Now.AddSeconds(10) }
        };

        LocalNotificationCenter.Current.Show(request);
    }
}