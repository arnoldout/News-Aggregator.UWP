using Facebook;
using NewsAggregator.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Authentication.Web;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using winsdkfb;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NewsAggregator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            FBlogin.Source= new BitmapImage(new Uri(this.BaseUri, "/Assets/Facebook Icon.ico"));
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            await AuthenticateFacebookAsync();
        }
        private async Task<String> AuthenticateFacebookAsync()
        {
            //Facebook app id
            var clientId = "935566066588259";
            //Facebook permissions
            var scope = "public_profile,email";

            var redirectUri = WebAuthenticationBroker.GetCurrentApplicationCallbackUri().ToString();
            var fb = new FacebookClient();
            Uri loginUrl = fb.GetLoginUrl(new
            {
                client_id = clientId,
                redirect_uri = redirectUri,
                response_type = "token",
                scope = scope
            });

            Uri startUri = loginUrl;
            Uri endUri = new Uri(redirectUri, UriKind.Absolute);
            WebAuthenticationResult result = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, startUri, endUri);

            if(result.ResponseStatus == (WebAuthenticationStatus.Success)){
                var pattern = string.Format("{0}#access_token={1}&expires_in={2}", WebAuthenticationBroker.GetCurrentApplicationCallbackUri(), "(?<access_token>.+)", "(?<expires_in>.+)");
                var match = Regex.Match(result.ResponseData, pattern);

                var access_token = match.Groups["access_token"];
                var expires_in = match.Groups["expires_in"];

                var AccessToken = access_token.Value;
                var TokenExpiry = DateTime.Now.AddSeconds(double.Parse(expires_in.Value));

                FacebookClient client = new FacebookClient(AccessToken);
                dynamic results = await client.GetTaskAsync("https://graph.facebook.com/v2.7/me?fields=id,name,email&access_token=" + AccessToken);
                dynamic email = results.email;
                dynamic name = results.name;
                Profile p = new Profile("faacebook"+email, name);
                String loginStatus = await ProfileService.login(p);
                if(loginStatus.Equals("false"))
                {
                    loginStatus = await ProfileService.Write(p);
                    if (!loginStatus.Equals("false"))
                    {
                        App.loginid = loginStatus;
                    }
                }
                Frame.Navigate(typeof(Feed));
            }
            //await ParseAuthenticationResult(result);
            return "";
        }

        private async void register_Click(object sender, RoutedEventArgs e)
        {
            String usr = txtUsrName.Text;
            String pass = txtPasswrd.Text;
            Profile p = new Profile(usr, pass);
            try
            {
                String result = await ProfileService.Write(p);
                if (!result.Equals("false"))
                {
                    App.loginid = result;
                }
                Frame.Navigate(typeof(Feed));
            }
            catch(AggregateException)
            {
                ProfileService.FailedRequest();
            }
            
        }

        private async void Mongologin_Click(object sender, RoutedEventArgs e)
        {
            String usr = txtUsrName.Text;
            String pass = txtPasswrd.Text;
            Profile p = new Profile(usr, pass);
            try
            {
                String id = await ProfileService.ParseRegResponse(await ProfileService.login(p), "Invalid Login");
                if(!id.Equals("false"))
                {
                    App.loginid = id;
                    Frame.Navigate(typeof(Feed));
                }
            }
            catch (AggregateException)
            {
                ProfileService.FailedRequest();
            }
        }
    }
}
