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
                RoleText.Text = $"{_loggedInStaff.Role}  |  {_loggedInStaff.Email}";
            }
        }

        private void DashboardButton_Click(object sender, RoutedEventArgs e)
        {
            DashboardHub.ScrollToSection(DashboardHub.Sections[0]);
        }

        private void MembersButton_Click(object sender, RoutedEventArgs e)
        {
            DashboardHub.ScrollToSection(DashboardHub.Sections[1]);
        }

        private void AccountsButton_Click(object sender, RoutedEventArgs e)
        {
            DashboardHub.ScrollToSection(DashboardHub.Sections[2]);
        }

        private async void ServiceButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string action = button?.Tag as string ?? "Service";
            await ShowMessageAsync(action, $"{action} selected. This action is available to authorised SACCO staff.");
        }

        private async void ReportButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string report = button?.Tag as string ?? "Report";
            await ShowMessageAsync(report, $"{report} is ready for authorised staff review.");
        }

        private async void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            await ShowMessageAsync("Logout", "You have successfully logged out.");

            Frame.Navigate(typeof(LoginPage));
            Frame.BackStack.Clear();
        }

        private async System.Threading.Tasks.Task ShowMessageAsync(string title, string message)
        {
            var dialog = new MessageDialog(message, title);
            await dialog.ShowAsync();
        }
    }
}
