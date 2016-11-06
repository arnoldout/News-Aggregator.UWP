using NewsAggregator.Data;
using NewsAggregator.Models;
using NewsAggregator.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
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
    public sealed partial class Feed : Page
    {
        NwsPaperViewModel nwsPaper { get; set; }

        public Feed()
        {
            this.InitializeComponent();
            nwsPaper = new NwsPaperViewModel();
            settings.Source = new BitmapImage(new Uri(this.BaseUri, "/Assets/settings_icon.png"));
        }
        
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.Frame.BackStack.Clear();
        }

        private void lvw_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = e.AddedItems?.FirstOrDefault();
            Story s = (StoryViewModel)item;
            Frame.Navigate(typeof(NwsViewer), s);
        }

        private void goToSettings(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(Settings));
        }
    }
}
