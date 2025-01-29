using Microsoft.EntityFrameworkCore;
using VictuzMobile.DatabaseConfig;
using VictuzMobile.DatabaseConfig.Models;

namespace VictuzMobile.App.ViewModels
{
    public class RegistrationsViewModel
    {
        public List<Registration> Registrations { get; set; } = [];

        private readonly DatabaseContext? DatabaseContext;
        private readonly int activityId;

        public RegistrationsViewModel(int id)
        {
            DatabaseContext = IPlatformApplication.Current?.Services.GetRequiredService<DatabaseContext>();
            activityId = id;

            PopulateRegistrations();
        }

        public async void PopulateRegistrations()
        {
            if (DatabaseContext is null)
            {
                return;
            }

            Registrations = await DatabaseContext.Registrations.Where(r => r.ActivityId == activityId).ToListAsync();
        }
    }
}
