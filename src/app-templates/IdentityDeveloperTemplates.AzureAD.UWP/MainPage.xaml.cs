using IdentityDeveloperTemplates.AzureAD.UWP.Services.Api;
using IdentityDeveloperTemplates.AzureAD.UWP.Services.Api.Interfaces;
using IdentityDeveloperTemplates.AzureAD.UWP.Services.Authentication;
using IdentityDeveloperTemplates.AzureAD.UWP.Services.Authentication.Interfaces;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IdentityDeveloperTemplates.AzureAD.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IApiService _apiService;
        private bool _isUserAuthenticated;
        private AuthenticationData _authenticationData;

        public MainPage()
        {
            this.InitializeComponent();
            _authenticationService = new AuthenticationService();
            _apiService = new ApiService();
        }

        private async void SignInButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (!_isUserAuthenticated)
            {
                SignInButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                SignInProgressRing.IsActive = true;

                _authenticationData = await _authenticationService.Authenticate();

                SignInButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
                SignInProgressRing.IsActive = false;

                if (_authenticationData != null)
                {
                    MessageDialog dialog = new MessageDialog("Welcome!");
                    await dialog.ShowAsync();
                    SignInButton.Content = "SIGN OUT";
                    _isUserAuthenticated = true;
                    CallApiButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
                }
            }

            else
            {
                SignInButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                SignInProgressRing.IsActive = true;

                await _authenticationService.SignOut();

                SignInButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
                SignInProgressRing.IsActive = false;
                SignInButton.Content = "SIGN IN";
                _isUserAuthenticated = false;
                CallApiButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        private async void CallApiButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            CallApiButton.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            CallApiProgressRing.IsActive = true;

            var apiResponse = await _apiService.GetGreetingFromApiAsync(_authenticationData);

            if (apiResponse != null)
            {
                MessageDialog dialog = new MessageDialog(apiResponse.GreetingFromApi);
                await dialog.ShowAsync();
            }

            CallApiButton.Visibility = Windows.UI.Xaml.Visibility.Visible;
            CallApiProgressRing.IsActive = false;
        }
    }
}
