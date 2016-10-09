using NewsAggregator.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
            String url = "";
            foreach (XmlDoc doc in nf.Docs)
            {
                foreach (Story s in doc.NewsItems)
                {
                    sb.Append(s.Title + "\n");
                    url = s.Uri;
                }
            }
            WebRequest wrGETURL = WebRequest.Create(url);
            wrGETURL.Proxy = null;
            WebResponse response = await wrGETURL.GetResponseAsync();
            Stream dataStream = response.GetResponseStream();
            TextReader tr = new StreamReader(dataStream);
            String str = "<td>mamma</td><td><strong>papa</strong></td>";
            str = removeTags(str);
            //title, guid, description, category 
            webVw.NavigateToString(str);


        }
        /*
        *
        *   Should work with asp api or whatever,
            UWP just doesn't support XPath atm
        *
        *
        public String removeTags(string str)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Properties.Resources.HtmlContents);
            var text = doc.DocumentNode.SelectNodes("//body//text()").Select(node => node.InnerText);
            StringBuilder output = new StringBuilder();
            foreach (string line in text)
            {
                output.AppendLine(line);
            }
            HttpUtility.HtmlDecode(output.ToString());
        }*/

    }
}
