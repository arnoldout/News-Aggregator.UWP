using NewsAggregator.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NewsAggregator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        public List<String> possLikes;
        public Settings()
        {
            this.InitializeComponent();
            backButton.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/back_Arrow.png"));
            getLikes();
        }
        public async void getLikes()
        {
            //populate suggestions box
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(String));

            //make get request to api
            String url = App.apiURL + "allLikes";
            WebRequest wrGETURL = WebRequest.Create(url);
            wrGETURL.Proxy = null;

            WebResponse response = await wrGETURL.GetResponseAsync();
            Stream dataStream = response.GetResponseStream();
            StreamReader objReader = new StreamReader(dataStream);
            dynamic likes = JsonConvert.DeserializeObject(objReader.ReadToEnd());
            dynamic articleLikes = likes.articles;
            possLikes = articleLikes[0].ToObject<List<String>>();
            possLikes.Sort();
            //display available topics
            suggestionBox.ItemsSource = possLikes;
        }

        private void suggestionBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            //update suggestions box as user enters text
            var Auto = (AutoSuggestBox)sender;
            if (Auto.Items.Count > 0)
            {
                var Suggestion = possLikes.Where(p => p.StartsWith(Auto.Text, StringComparison.OrdinalIgnoreCase)).ToArray();
                if (Suggestion.Count() > 0)
                {
                    Auto.ItemsSource = Suggestion;
                }
                else
                {
                    List<String> tmp = new List<string>();
                    tmp.Add("No Results");
                    Auto.ItemsSource = tmp;
                }
            }
        }
       
        private void suggestionBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            //take user's suggestion, add to their account
            var Auto = (AutoSuggestBox)sender;
            if (args.ChosenSuggestion != null&&(!args.ChosenSuggestion.Equals("No Results")))
            {
                String like = args.ChosenSuggestion.ToString();
                Auto.Text = "";
                Auto.ItemsSource = possLikes;
                StoryService.addLike(like, App.loginid);
            }
            else
            {
                
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //return to Feed
            Frame.GoBack();
        }
    }
}
