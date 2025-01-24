using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictuzMobile.DatabaseConfig.Models;

namespace VictuzMobile.App.Services
{
    public class SecureStorageService
    {
        private const string UserIdStorageKey = "victuz_current_user_id";

        public static void ClearCurrentUserId()
        {
            SecureStorage.Remove(UserIdStorageKey);
        }

        public static async Task StoreUserId(int userId)
        {
            await SecureStorage.SetAsync(UserIdStorageKey, userId.ToString());
        }

        public static async Task<int?> GetCurrentUserId()
        {
            var userId = await SecureStorage.GetAsync(UserIdStorageKey);

            return userId is not null ? int.Parse(userId) : null;
        }
    }
}
