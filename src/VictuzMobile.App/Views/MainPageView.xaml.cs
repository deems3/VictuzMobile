using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using VictuzMobile.App.ViewModels;
using VictuzMobile.DatabaseConfig;
using VictuzMobile.DatabaseConfig.Models;

namespace VictuzMobile.App.Views;

public partial class MainPageView : ContentPage
{
    public MainPageViewModel ViewModel { get; set; }
    private const string ImageNotFoundUrl = "https://media.istockphoto.com/id/1409329028/vector/no-picture-available-placeholder-thumbnail-icon-illustration-design.jpg?s=612x612&w=0&k=20&c=_zOuJu755g2eEUioiOUdz_mHKJQJn-tDgIAhQzyeKUQ=";

    public MainPageView(DatabaseContext context) {
        InitializeComponent();

        ViewModel = new MainPageViewModel();

        var activities = context.Activities.Where(a => a.StartDate >= DateTime.Now)
            .OrderBy(a => a.StartDate)
            .Take(3)
            .ToList();

        ViewModel.UpcomingActivities = new ObservableCollection<Activity>(activities);

        GenerateFact();
        InitializeActivities();

        BindingContext = ViewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        InitializeActivities();
    }

    private async void GenerateFact()
    {
        ViewModel.Fact = await FactAPIVM.GetRandomFact();
    }

    private void InitializeActivities()
    {
        var first = ViewModel.UpcomingActivities.ElementAtOrDefault(0);
        var second = ViewModel.UpcomingActivities.ElementAtOrDefault(1);
        var third = ViewModel.UpcomingActivities.ElementAtOrDefault(2);

        firstActivity.Source = first?.ImageURL ?? ImageNotFoundUrl;
        firstActivityTitle.Text = first?.Name ?? "No activity found";
        firstActivityStartDate.Text = first?.StartDate.ToShortDateString() ?? "no date";
        secondActivity.Source = second?.ImageURL ?? ImageNotFoundUrl;
        secondActivityTitle.Text = second?.Name ?? "No activity found";
        secondActivityStartDate.Text = second?.StartDate.ToShortDateString() ?? "no date";
        thirdActivity.Source = third?.ImageURL ?? ImageNotFoundUrl;
        thirdActivityTitle.Text = third?.Name ?? "No activity found";
        thirdActivityStartDate.Text = third?.StartDate.ToShortDateString() ?? "no date";
    }

    private async void thirdActivity_Clicked(object sender, EventArgs e)
    {
        var third = ViewModel.UpcomingActivities.ElementAtOrDefault(2);
        if (third is not null)
        {
            await Navigation.PushAsync(new ActivityDetailsView(third.Id));
        }
    }

    private async void secondActivity_Clicked(object sender, EventArgs e)
    {
        var second = ViewModel.UpcomingActivities.ElementAtOrDefault(1);
        if (second is not null)
        {
            await Navigation.PushAsync(new ActivityDetailsView(second.Id));
        }
    }

    private async void firstActivity_Clicked(object sender, EventArgs e)
    {
        var first = ViewModel.UpcomingActivities.ElementAtOrDefault(0);
        if (first is not null)
        {
            await Navigation.PushAsync(new ActivityDetailsView(first.Id));
        }
    }
}