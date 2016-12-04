using Facebook;
using Mntone.SvgForXaml;
using NewsAggregator.Data;
using NewsAggregator.ViewModels;
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
        LoginViewModel loginVM;
        public MainPage()
        {
            this.InitializeComponent();
            //initialize view model
            loginVM = new LoginViewModel();
            //setting page image sources
            imgTitle.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/The Daily Feed Logo.png"));
            FBlogin.Source= new BitmapImage(new Uri(this.BaseUri, "/Assets/Facebook Icon.ico"));
        }
        

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            await AuthenticateFacebookAsync();
        }
        private async Task<String> AuthenticateFacebookAsync()
        {
            //start progressRing
            loginVM.switchIsActive();
            //start facebook login process
            FBSession session = FBSession.ActiveSession;
            session.FBAppId = (935566066588259).ToString();
            List<String> permissionList = new List<String>();//list of all the permissions needed from the user
            permissionList.Add("public_profile");
            permissionList.Add("email");

            FBPermissions permissions = new FBPermissions(permissionList);
            //login
            var result = await session.LoginAsync(permissions);
            if (result.Succeeded)
            { 
                //user successfully logged into facebook
                String email = session.User.Id+session.User.Name;
                String pass = session.User.Id;

                //create profile for user
                Profile p = new Profile(email, pass);
                //check if user already has account
                String loginStatus = await ProfileService.login(p);
                if (loginStatus.Equals("false"))
                {
                    //account not created yet, register user
                    loginStatus = await ProfileService.Write(p);
                    if (!loginStatus.Equals("false"))
                    {
                        //new user account created
                        //user logged in
                        App.loginid = loginStatus;
                        Frame.Navigate(typeof(Feed));
                    }
                }
                else
                {
                    //user logged in
                    App.loginid = loginStatus;
                    Frame.Navigate(typeof(Feed));
                }
            }
            loginVM.switchIsActive();
            return "false";
        }

        private async void register_Click(object sender, RoutedEventArgs e)
        {
            loginVM.switchIsActive();
            //use textboxes as fields for new account
            String usr = txtUsrName.Text;
            String pass = txtPasswrd.Password;
            Profile p = new Profile(usr, pass);
            try
            {
                //try to register
                String result = await ProfileService.Write(p);
                if (!result.Equals("false"))
                {
                    //log into new account
                    loginVM.switchIsActive();
                    App.loginid = result;
                    Frame.Navigate(typeof(Feed));
                }
            }
            catch(AggregateException)
            {
                //account already created
                ProfileService.FailedRequest();
            }
            loginVM.switchIsActive();
        }

        private async void Mongologin_Click(object sender, RoutedEventArgs e)
        {
            loginVM.switchIsActive();
            //login user 
            String usr = txtUsrName.Text;
            String pass = txtPasswrd.Password;
            Profile p = new Profile(usr, pass);
            try
            {
                //attempt to login
                String id = await ProfileService.ParseRegResponse(await ProfileService.login(p), "Invalid Login");
                if(!id.Equals("false"))
                {
                    //user logged in successfully
                    loginVM.switchIsActive();
                    App.loginid = id;
                    Frame.Navigate(typeof(Feed));
                }
            }
            catch (AggregateException)
            {
                //user failed to login
                ProfileService.FailedRequest();
            }
            loginVM.switchIsActive();
        }
    }
}
