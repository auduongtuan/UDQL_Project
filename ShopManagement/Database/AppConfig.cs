using Microsoft.IdentityModel.Tokens;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace ShopManagement
{
    class AppConfig
    {
        public static string Server = "";
        public static string Database = "";
        public static string Username = "";
        public static string Password = "";
        public static string Entropy = "";
        public static int LastTabIndex = -1;
        public static void LoadAuthentication()
        {
            var config = ConfigurationManager.AppSettings;
            Server = config["Server"] ?? "";
            Database = config["Database"] ?? "";
            Username = config["Username"] ?? "";
            var passwordInt64 = config["Password"] ?? "";
            var entropyInt64 = config["Entropy"] ?? "";
            if (!passwordInt64.IsNullOrEmpty())
            {
                var passwordInBytes = Convert.FromBase64String(passwordInt64);
                var entropyInBytes = Convert.FromBase64String(entropyInt64);
                var unencryptedPassword = ProtectedData.Unprotect(passwordInBytes, entropyInBytes, DataProtectionScope.CurrentUser);
                Password = Encoding.UTF8.GetString(unencryptedPassword);
            }
        }
        public static void LoadInfo()
        {
            var config = ConfigurationManager.AppSettings;
            try
            {
                LastTabIndex = Int32.Parse(config["LastTabIndex"] ?? "0");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
        public static void SaveInfo()
        {
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["LastTabIndex"].Value = LastTabIndex.ToString();
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }
        public static void SaveAuthentication()
        {
            var passwordInBytes = Encoding.UTF8.GetBytes(Password);
            var entropy = new byte[20];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(entropy);
            }
            var cypherText = ProtectedData.Protect(passwordInBytes, entropy, DataProtectionScope.CurrentUser);
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["Server"].Value = Server;
            config.AppSettings.Settings["Database"].Value = Database;
            config.AppSettings.Settings["Username"].Value = Username;
            config.AppSettings.Settings["Password"].Value = Convert.ToBase64String(cypherText);
            config.AppSettings.Settings["Entropy"].Value = Convert.ToBase64String(entropy);
            config.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
