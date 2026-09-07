using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Assignment7
{
    public sealed partial class LoginPage : Page
    {
        private readonly DatabaseService _databaseService = new DatabaseService();

        public LoginPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorTextBlock.Visibility = Visibility.Collapsed;

            string email = EmailTextBox.Text.Trim();
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ShowError("Please enter both your email address and password.");
                return;
            }

            if (!email.Contains("@"))
            {
                ShowError("Please enter a valid email address.");
                return;
            }

            LoginButton.IsEnabled = false;
            LoginProgress.IsActive = true;

            try
            {
                Staff = await _databaseService.AuthenticateStaffAsync(email, password);

                if (Staff == null)
                {
                    ShowError("Invalid email or password.");
                    return;
                }

                Frame.Navigate(typeof(HomePage), Staff);
            }
            catch (Exception)
            {
                ShowError("Unable to connect to the SACCO database. Check the SQL Server connection settings.");
            }
            finally
            {
                LoginButton.IsEnabled = true;
                LoginProgress.IsActive = false;
            }
        }

        public Models.Staff Staff { get; private set; }

        private void ShowError(string message)
        {
            ErrorTextBlock.Text = message;
            ErrorTextBlock.Visibility = Visibility.Visible;
        }
    }
}
