using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using DatabaseConfig.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using VictuzMobile.App.Services;
using VictuzMobile.App.Views;
using VictuzMobile.DatabaseConfig;

namespace VictuzMobile.App.ViewModels
{
    public class SuggestionsViewModel : INotifyPropertyChanged
    {
        public Suggestion? Suggestion
        {
            get => _suggestion;
            set
            {
                _suggestion = value;
                OnPropertyChanged();
            }
        }

        public List<DatabaseConfig.Models.Location> SuggestionLocations { get; set; } = [];

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand SaveSuggestionCommand { get; }
        public ICommand EditSuggestionCommand { get; }
        public ICommand CreateNewLocationCommand { get; }
        public ICommand LikeSuggestionCommand { get; }
        public ICommand RefreshSuggestionCommand { get; }
        public ICommand CreateSuggestionCommand { get; }

        private readonly DatabaseContext? DatabaseContext;
        private readonly INavigation _navigation;
        private readonly int suggestionId;
        private Suggestion? _suggestion;


        public SuggestionsViewModel(INavigation navigation, int id)
        {
            DatabaseContext = IPlatformApplication.Current?.Services.GetRequiredService<DatabaseContext>();
            _navigation = navigation;
            suggestionId = id;

            SaveSuggestionCommand = new Command(SaveSuggestion);
            EditSuggestionCommand = new Command(EditSuggestion);
            CreateNewLocationCommand = new Command(CreateNewLocation);
            LikeSuggestionCommand = new Command(LikeSuggestion);
            RefreshSuggestionCommand = new Command(RefreshSuggestion);

            GetSuggestion();
        }

        public SuggestionsViewModel(INavigation navigation)
        {
            DatabaseContext = IPlatformApplication.Current?.Services.GetRequiredService<DatabaseContext>();
            _navigation = navigation;

            CreateSuggestionCommand = new Command(async () => await CreateSuggestion());
            CreateNewLocationCommand = new Command(CreateNewLocation);

            CreateEmptySuggestion();
        }

        private async void GetSuggestion()
        {
            if (DatabaseContext == null)
            {
                var toast = Toast.Make("Failed to retrieve database", textSize: 20);
                await toast.Show();
                await _navigation.PopAsync();
                return;
            }

            var suggestion = await DatabaseContext.Suggestions
                .Include(s => s.Organiser)
                .Include(s => s.Location)
                .Include(s => s.LikedByUsers)
                .FirstOrDefaultAsync(s => s.Id == suggestionId);

            if (suggestion == null)
            {
                var toast = Toast.Make("Failed to retrieve suggestion from database", textSize: 20);
                await toast.Show();
                await _navigation.PopAsync();
                return;
            }

            Suggestion = suggestion;

            await RetrieveLocations();
        }

        private async void SaveSuggestion()
        {
            if (DatabaseContext == null || Suggestion == null)
            {
                var toast = Toast.Make("Failed to save suggestion", textSize: 20);
                await toast.Show();
                return;
            }

            DatabaseContext.Suggestions.Update(Suggestion);
            await DatabaseContext.SaveChangesAsync();
            await _navigation.PopModalAsync();
            OnPropertyChanged(nameof(Suggestion));
        }

        private async void EditSuggestion()
        {
            await _navigation.PushModalAsync(new SuggestionView(suggestionId, editmode: true));
            return;
        }

        private async void CreateNewLocation()
        {
            var toast = Toast.Make("Creating a new location is currently not implemented", textSize: 20);
            await toast.Show();
            return;
        }

        private async void LikeSuggestion()
        {
            // get the userid from the secure storage
            // get the user from the database
            // check if the user has already liked the suggestion
            //  if yes: remove the like
            //  if no: add the like
            // update the suggestion in the database

            IToast toast;

            if (DatabaseContext == null || Suggestion == null)
            {
                toast = Toast.Make("Failed", textSize: 20);
                await toast.Show();
                return;
            }

            var currentUserId = await SecureStorageService.GetCurrentUserId();
            
            if (currentUserId != null)
            {
                var user = await DatabaseContext.Users.FindAsync(currentUserId);

                if (user == null)
                {
                    toast = Toast.Make("Failed to retrieve user id", textSize: 20);
                    await toast.Show();
                    return;
                }

                if (Suggestion.LikedByUsers.Any(u => u.Id == currentUserId))
                {
                    Suggestion.LikedByUsers.Remove(user);
                    toast = Toast.Make("Like removed", textSize: 20);
                }
                else
                {
                    Suggestion.LikedByUsers.Add(user);
                    toast = Toast.Make("Liked", textSize: 20);
                }

                DatabaseContext.Suggestions.Update(Suggestion);
                await DatabaseContext.SaveChangesAsync();
                await toast.Show();
                OnPropertyChanged(nameof(Suggestion));
                return;
            }

            toast = Toast.Make("Failed to retrieve user id", textSize: 20);
            await toast.Show();
        }

        private void RefreshSuggestion()
        {
            OnPropertyChanged(nameof(Suggestion));
        }

        private async void CreateEmptySuggestion()
        {
            var userId = await SecureStorageService.GetCurrentUserId();

            if (userId == null)
            {
                var toast = Toast.Make("Failed to create new suggestion (no userid)", textSize: 20);
                await toast.Show();
                return;
            }

            Suggestion = new Suggestion()
            {
                Name = "New suggestion",
                Description = "Description",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                MaxRegistrations = 10,
                OrganiserId = (int)userId,
                LocationId = 1,
                CategoryId = 1,
                ImageURL = "https://img.freepik.com/free-photo/ai-human-technology-background_1409-5588.jpg"
            };

            await RetrieveLocations();
        }

        private async Task CreateSuggestion()
        {
            if (DatabaseContext == null || Suggestion == null)
            {
                var toast = Toast.Make("Failed to retrieve database or suggestion", textSize: 20);
                await toast.Show();
                return;
            }

            try
            {
                await DatabaseContext.Suggestions.AddAsync(Suggestion);
                await DatabaseContext.SaveChangesAsync();
            }
            catch (Exception ex) {}

            await Application.Current.MainPage.DisplayAlert("ERROR", "Creating suggestions is not functional at the moment", "OK");
            await _navigation.PopAsync();
        }

        private async Task RetrieveLocations()
        {
            if (DatabaseContext == null)
            {
                var toast = Toast.Make("Failed to retrieve database for locations", textSize: 20);
                await toast.Show();
                return;
            }

            SuggestionLocations = new(await DatabaseContext.Locations.ToListAsync());
        }

        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}