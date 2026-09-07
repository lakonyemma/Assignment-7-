using System;
using Assignment7.Models;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Assignment7
{
    public sealed partial class HomePage : Page
    {
        private Staff _loggedInStaff;

        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            _loggedInStaff = e.Parameter as Staff;

            if (_loggedInStaff != null)
            {
                WelcomeText.Text = $"Welcome, {_loggedInStaff.FullName}";
                RoleText.Text = $"Signed in as {_loggedInStaff.Role} | {_loggedInStaff.Email}";
            }
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            DashboardHub.ScrollToSection(DashboardHub.Sections[0]);
        }

        private async void MembersButton_Click(object sender, RoutedEventArgs e)
        {
            await ShowMessageAsync("Members", "Member management is available to authorised SACCO staff.");
        }

        private async void AccountsButton_Click(object sender, RoutedEventArgs e)
        {
            await ShowMessageAsync("Accounts", "Account management is available to authorised SACCO staff.");
        }

        private async void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            DashboardHub.ScrollToSection(DashboardHub.Sections[1]);
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
            else
                Frame.Navigate(typeof(LoginPage));
        }

        private async System.Threading.Tasks.Task ShowMessageAsync(string title, string message)
        {
            var dialog = new MessageDialog(message, title);
            await dialog.ShowAsync();
        }
    }
}
