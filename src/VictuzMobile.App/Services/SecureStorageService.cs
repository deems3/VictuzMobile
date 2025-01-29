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
        private const string UserAuthenticatedKey = "victuz_user_authenticated";
        private const string AppDarkModeKey = "victuz_settings_darkmode";
        private const string AppAutomaticThemeKey = "victuz_settings_automatictheme";
        private const string AppPushNotifictionsKey = "victuz_settings_pushnotifications";
        private const string AppFingerprintKey = "victuz_settings_fingerprint";
        private const string AppFaceIdKey = "victuz_settings_faceid";

        public static void ClearCurrentUser()
        {
            SecureStorage.Remove(UserIdStorageKey);
            SecureStorage.Remove(UserAuthenticatedKey);
        }

        public static async Task StoreUser(int userId)
        {
            await SecureStorage.SetAsync(UserIdStorageKey, userId.ToString());
            await SecureStorage.SetAsync(UserAuthenticatedKey, "true");
        }

        public static async Task<int?> GetCurrentUserId()
        {
            var userId = await SecureStorage.GetAsync(UserIdStorageKey);

            return userId is not null ? int.Parse(userId) : null;
        }

        public static async Task<bool> GetAuthenticationStatus()
        {
            var isAuthenticated = await SecureStorage.GetAsync(UserAuthenticatedKey);
            var userId = await SecureStorage.GetAsync(UserIdStorageKey);

            return isAuthenticated is not null && userId is not null;
        }

        public static async Task<bool> GetDarkMode()
        {
            var darkMode = await SecureStorage.GetAsync(AppDarkModeKey);
            return darkMode is not null && bool.Parse(darkMode);
        }

        public static async Task<bool> GetAutomaticThemeMode()
        {
            var automaticTheme = await SecureStorage.GetAsync(AppAutomaticThemeKey);

            if (automaticTheme is null) // when the key is not set, set the default value to 'true' as automatic themes are enabled by default by MAUI.
            {
                await SetAutomaticThemeMode(true);
                return true;
            }

            return bool.Parse(automaticTheme);
        }

        public static async Task SetDarkMode(bool darkMode)
        {
            await SecureStorage.SetAsync(AppDarkModeKey, darkMode.ToString());
        }

        public static async Task SetAutomaticThemeMode(bool automaticTheme)
        {
            if (automaticTheme)
            {
                await SetDarkMode(false);
            }

            await SecureStorage.SetAsync(AppAutomaticThemeKey, automaticTheme.ToString());
        }

        public static async Task<bool> GetPushNotifications()
        {
            var pushNotifications = await SecureStorage.GetAsync(AppPushNotifictionsKey);

            if (pushNotifications is null) // set enabled as default.
            {
                await SetPushNotifications(true);
                return true;
            }

            return bool.Parse(pushNotifications);
        }

        public static async Task SetPushNotifications(bool pushNotifications)
        {
            await SecureStorage.SetAsync(AppPushNotifictionsKey, pushNotifications.ToString());
        }

        public static async Task<bool> GetFingerprint()
        {
            var fingerprint = await SecureStorage.GetAsync(AppFingerprintKey);
            return fingerprint is not null && bool.Parse(fingerprint);
        }

        public static async Task SetFingerprint(bool fingerprint)
        {
            await SecureStorage.SetAsync(AppFingerprintKey, fingerprint.ToString());
        }
    }
}
