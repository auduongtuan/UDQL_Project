using Microsoft.IdentityModel.Tokens;
using ShopManagement.View;
using System;
using System.Windows;

namespace ShopManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void serverSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            var screen = new ConfigWindow();
            screen.ShowDialog();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            bool? rememberPassword = rememberPasswordCheckbox.IsChecked;
            if (usernameTextbox.Text.IsNullOrEmpty() || passwordBox.Password.IsNullOrEmpty())
            {
                MessageBox.Show("Please enter username and password!");
                return;
            }
            try
            {
                Db.ConnectDatabase(usernameTextbox.Text, passwordBox.Password);
                if (Db.IsConnected)
                {
                    if (rememberPassword == true)
                    {
                        AppConfig.Username = usernameTextbox.Text;
                        AppConfig.Password = passwordBox.Password;
                        AppConfig.SaveAuthentication();
                    }
                    var listScreen = new MainWindow();
                    listScreen.Show();
                    //MessageBox.Show("Login success");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cannot connect with: "+Db.GetConnectionString());
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AppConfig.LoadAuthentication();
            if (!AppConfig.Username.IsNullOrEmpty())
            {
                usernameTextbox.Text = AppConfig.Username;
            }
            if (!AppConfig.Password.IsNullOrEmpty())
            {
                passwordBox.Password = AppConfig.Password;
            }

        }
    }
}
