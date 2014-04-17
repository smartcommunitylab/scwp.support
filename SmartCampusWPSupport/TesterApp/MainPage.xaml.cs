using AuthenticationLibrary;
using Microsoft.Phone.Controls;
using Models.AuthorizationService;
using System.Windows;

namespace TesterApp
{
    public partial class MainPage : PhoneApplicationPage
    {
        string secret = "f3ea5378-43ba-42c3-b2bf-5f7cd10b6e6e";
        string clientid = "52482826-891e-4ee0-9f79-9153a638d6e4";
        string redirectUrl = "http://localhost";
        string code;
        AuthLibrary authLib;
        ProfileLibrary.ProfileLibrary proLib;
        TokenModel toMo;

        public MainPage()
        {
            InitializeComponent();
            authLib = new AuthLibrary(clientid, secret, redirectUrl);
        }
        private void Button_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            banana.Navigate(AuthUriHelper.GetCodeUri(clientid, redirectUrl));
        }

        private void banana_Navigating(object sender, NavigatingEventArgs e)
        {
            if (e.Uri.Host.ToString() == "localhost")
            {
                code = e.Uri.Query.Split('=')[1];
                MessageBox.Show("Ho un code: " + code);

            }
        }

        private async void btnGetToken_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            toMo = await authLib.GetAccessToken(code);
            coop.Text = toMo.Scope;
            MessageBox.Show("Ho un token: " + toMo.AccessToken);
        }

        private async void btngetuser_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            //authLib = new AuthLibrary(clientid, secret, redirectUrl, toMo.AccessToken, toMo.RefreshToken);
            proLib = new ProfileLibrary.ProfileLibrary(toMo.AccessToken);
            Models.ProfileService.BasicProfile ap = await proLib.GetBasicProfile();
            coop2.Text = ap.Name;
        }
    }
}