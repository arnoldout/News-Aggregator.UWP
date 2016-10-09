using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NewsAggregator.Models
{
    public abstract class XmlDoc
    {
        private List<Story> newsItems = new List<Story>();

        internal List<Story> NewsItems
        {
            get
            {
                return newsItems;
            }

            set
            {
                newsItems = value;
            }
        }

        public abstract Task parseXml();

        public async Task<XmlDocument> getXml(String uri)
        {
            XmlDocument xmlDoc = new XmlDocument(); // Create an XML document object
            String url = uri;
            WebRequest wrGETURL = WebRequest.Create(url);
            wrGETURL.Proxy = null;

            WebResponse response = await wrGETURL.GetResponseAsync();
            Stream dataStream = response.GetResponseStream();
            xmlDoc.Load(dataStream); // Load the XML document from the specified file
            return xmlDoc;
        }
    }
}
