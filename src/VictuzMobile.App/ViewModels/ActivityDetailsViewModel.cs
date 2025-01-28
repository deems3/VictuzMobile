using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    class ActivityDetailsViewModel
    {
        private DatabaseContext? _context;
        private readonly INavigation _navigation;
        private ICommand NavigateToManagePageCommand { get; }
        private ICommand RegisterForActivityCommand { get; }
        public Activity? Activity { get; set; }

        public ActivityDetailsViewModel(INavigation navigation, int id)
        {
            _context = IPlatformApplication.Current?.Services.GetRequiredService<DatabaseContext>();
            _navigation = navigation;
            NavigateToManagePageCommand = new Command<int>(NavigateToManagePage);
            RegisterForActivityCommand = new Command(RegisterForActivity);


            Activity = _context?.Activities
                .Where(a => a.Id == id)
                .Include(a => a.Organiser)
                .Include(a => a.Location)
                .Include(a => a.Registration)
                .FirstOrDefault();
        }

        private async void NavigateToManagePage(int id)
        {
            await _navigation.PushAsync(new ManageActivityView(id));
        }

        private async void RegisterForActivity()
        {
            // check if user is already registered for activity.
            //  if not, register for activity.
            //  if yes, unregister for activity.
            // send back result to user by pop-up message.
            var userId = await SecureStorageService.GetCurrentUserId();
            if (Activity == null || userId == null)
            {
                return;
            }

            foreach (var registration in Activity?.Registration)
            {
                if (registration.UserId == userId)
                {
                    _context?.Registrations.Remove(registration);
                    await _context.SaveChangesAsync();
                    return;
                }
            }
        }
    }
}
