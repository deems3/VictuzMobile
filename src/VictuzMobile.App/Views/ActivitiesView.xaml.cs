using DatabaseConfig.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using VictuzMobile.App.ViewModels;
using VictuzMobile.DatabaseConfig;
using VictuzMobile.DatabaseConfig.Models;

namespace VictuzMobile.App.Views;

public partial class ActivitiesView : ContentPage
{
    public ActivitiesViewViewModel ViewModel { get; set; }
    public ActivitiesView(DatabaseContext context)
    {
        InitializeComponent();

        ViewModel = new ActivitiesViewViewModel(Navigation);

        BindingContext = ViewModel;
    }

    private void YourActivityFilterButton_Clicked(object sender, EventArgs e)
    {

    }

    private void AllActivityFilterButton_Clicked(object sender, EventArgs e)
    {

    }

    private void SuggestionActivityFilterButton_Clicked(object sender, EventArgs e)
    {

    }
}