using Facebook;
using Mntone.SvgForXaml;
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
using Windows.Storage;
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
            imgTitle.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/The Daily Feed Logo.png"));
            FBlogin.Source= new BitmapImage(new Uri(this.BaseUri, "/Assets/Facebook Icon.ico"));
        }
        

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            await AuthenticateFacebookAsync();
        }
        private async Task<String> AuthenticateFacebookAsync()
        {
            FBSession session = FBSession.ActiveSession;
            session.FBAppId = (935566066588259).ToString();
            List<String> permissionList = new List<String>();//list of all the permissions needed from the user
            permissionList.Add("public_profile");
            permissionList.Add("email");

            FBPermissions permissions = new FBPermissions(permissionList);
            var result = await session.LoginAsync(permissions);
            if (result.Succeeded)
            { 
                String email = session.User.Id+session.User.Name;
                String pass = session.User.Id;

                Profile p = new Profile(email, pass);
                String loginStatus = await ProfileService.login(p);
                if (loginStatus.Equals("false"))
                {
                    loginStatus = await ProfileService.Write(p);
                    if (!loginStatus.Equals("false"))
                    {
                        App.loginid = loginStatus;
                        Frame.Navigate(typeof(Feed));
                    }
                }
                else
                {
                    App.loginid = loginStatus;
                    Frame.Navigate(typeof(Feed));
                }
            }
            return "false";
        }

        private async void register_Click(object sender, RoutedEventArgs e)
        {
            String usr = txtUsrName.Text;
            String pass = txtPasswrd.Password;
            Profile p = new Profile(usr, pass);
            try
            {
                String result = await ProfileService.Write(p);
                if (!result.Equals("false"))
                {
                    App.loginid = result;
                    Frame.Navigate(typeof(Feed));
                }
            }
            catch(AggregateException)
            {
                ProfileService.FailedRequest();
            }
            
        }

        private async void Mongologin_Click(object sender, RoutedEventArgs e)
        {
            String usr = txtUsrName.Text;
            String pass = txtPasswrd.Password;
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
