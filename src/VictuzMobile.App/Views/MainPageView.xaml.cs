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
        secondActivity.Source = second?.ImageURL ?? ImageNotFoundUrl;
        secondActivityTitle.Text = second?.Name ?? "No activity found";
        thirdActivity.Source = third?.ImageURL ?? ImageNotFoundUrl;
        thirdActivityTitle.Text = third?.Name ?? "No activity found";
    }
}