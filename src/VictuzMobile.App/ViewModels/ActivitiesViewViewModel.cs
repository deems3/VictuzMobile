using CommunityToolkit.Mvvm.ComponentModel;
using DatabaseConfig.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VictuzMobile.App.Services;
using VictuzMobile.App.Views;
using VictuzMobile.DatabaseConfig;
using VictuzMobile.DatabaseConfig.Models;

namespace VictuzMobile.App.ViewModels
{
    public partial class ActivitiesViewViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Activity> allActivities = [];
        [ObservableProperty]
        public ObservableCollection<Activity> registeredActivities = [];
        [ObservableProperty]
        public ObservableCollection<Suggestion> suggestions = [];

        public ICommand NavigateToActivityCommand { get; }
        public ICommand LikeSuggestionCommand { get; }
        private readonly INavigation _navigation;
        private readonly DatabaseContext _context;
        private readonly AuthService _authenticationService;

        public ActivitiesViewViewModel(INavigation navigation)
        {
            _navigation = navigation;
            NavigateToActivityCommand = new Command<int>(NavigateToActivity);
            LikeSuggestionCommand = new Command<int>(LikeSuggestion);
            _context = IPlatformApplication.Current.Services.GetRequiredService<DatabaseContext>();
            _authenticationService = IPlatformApplication.Current.Services.GetRequiredService<AuthService>();

            PopulateCollections();
        }

        private async void NavigateToActivity(int id)
        {
            await _navigation.PushAsync(new ActivityDetailsView(id));
        }

        private async void LikeSuggestion(int id)
        {
            var currentUserId = await SecureStorageService.GetCurrentUserId();

            if (currentUserId == null)
            {
                return;
            }

            var user = _authenticationService.GetUser((int)currentUserId);

            if (user == null)
            {
                return;
            }


            var suggestionToLike = Suggestions.First(s => s.Id == id);

            if (suggestionToLike.LikedByUsers.Any(u => u.Id == currentUserId))
            {
                // Suggestion already liked, remove the like
                suggestionToLike.LikedByUsers.Remove(user);
            }
            else
            {
                suggestionToLike.LikedByUsers.Add(user);
            }

            _context.Suggestions.Update(suggestionToLike);
            await _context.SaveChangesAsync();

            // Update the suggestion in place to trigger a re-render of the collection
            var index = Suggestions.IndexOf(suggestionToLike);
            Suggestions[index] = suggestionToLike;
        }

        public async Task PopulateCollections()
        {
            int? userId = await SecureStorageService.GetCurrentUserId();

            RegisteredActivities = new ObservableCollection<Activity>(await _context.Activities
                .Include(a => a.Registration)
                .Where(a => a.StartDate >= DateTime.Now && a.Registration.Any(r => r.UserId == userId))
                .OrderBy(a => a.StartDate)
                .ToListAsync());

            AllActivities = new ObservableCollection<Activity>(await _context.Activities
                .Where(a => a.StartDate >= DateTime.Now)
                .OrderBy(a => a.StartDate)
                .ToListAsync());

            Suggestions = new ObservableCollection<Suggestion>(await _context.Suggestions
                .Where(s => s.StartDate >= DateTime.Now)
                .OrderBy(s => s.StartDate)
                .Include(s => s.LikedByUsers)
                .ToListAsync());
        }

        public async Task PopulateRegisteredActivities()
        {
            int? userId = await SecureStorageService.GetCurrentUserId();

            RegisteredActivities = new ObservableCollection<Activity>(await _context.Activities
                .Include(a => a.Registration)
                .Where(a => a.StartDate >= DateTime.Now && a.Registration.Any(r => r.UserId == userId))
                .OrderBy(a => a.StartDate)
                .ToListAsync());
        }
    }
}
