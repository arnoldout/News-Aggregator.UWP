using NewsAggregator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NewsAggregator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Feed : Page
    {
        public Feed()
        {
            this.InitializeComponent();
            getNytXmlFeed();
        }
        public async Task getNytXmlFeed()
        {
            StringBuilder sb = new StringBuilder();
            NewsFactory nf = new NewsFactory();
            await nf.getDocs();
            Task.WaitAll();
            foreach (XmlDoc doc in nf.Docs)
            {
                foreach (Story s in doc.NewsItems)
                {
                    sb.Append(s.Title + "\n");
                }
            }
            //title, guid, description, category 
            tb1.Text = sb.ToString();
        }
    }
}
