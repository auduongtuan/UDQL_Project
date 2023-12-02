using System;
// using System.Data.SqlClient;
using System.Windows;

namespace ShopManagement
{
    internal class Db
    {
        private static string? Username { get; set; }
        private static string? Password { get; set; }
        public static bool IsConnected { get; set; }
        static Db()
        {
            IsConnected = false;
        }
        public static string GetConnectionString()
        {
            // return "Server=.\\SQLEXPRESS;Database=udql_inventory;TrustServerCertificate=True;User Id=sa;Password=RPSsql12345";
            AppConfig.LoadAuthentication();
            string server = AppConfig.Server;
            string database = AppConfig.Database;
            string username = Username != null ? Username : AppConfig.Username;
            string password = Password != null ? Password : AppConfig.Password;
            //if (server.IsNullOrEmpty() || database.IsNullOrEmpty() || username.IsNullOrEmpty()) return "";
            // comment beacause bug when build
            //var sConnB = new SqlConnectionStringBuilder()
            //{
            //    DataSource = server,
            //    InitialCatalog = database,
            //    UserID = username,
            //    Password = password,
            //    TrustServerCertificate = true
            //};
            // return sConnB.ConnectionString;
            string cs = $"Server={server};Database={database};User Id={username};Password={password};TrustServerCertificate=True;";
            return cs;
        }

        public static void ConnectDatabase(string? _username = null, string? _password = null)
        {
            //var config = new ConfigurationBuilder().AddUserSecrets<MobilePhoneWindow>().Build();
            //string connectionString = config.GetSection("DB")["ConnectionString"];
            if (_username != null)
            {
                Username = _username;
            }
            if (_password != null)
            {
                Password = _password;
            }
            try
            {
                using (var context = new UdqlInventoryContext())
                {
                    if (context.Database.CanConnect())
                    {
                        IsConnected = true;
                    }
                    else
                    {
                        IsConnected = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
