using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NewsAggregator.Models
{
    class BBCDoc : XmlDoc
    {
        public override async Task parseXml()
        {
            XmlDocument xmlDoc = await getXml("http://feeds.bbci.co.uk/news/rss.xml");
            XmlNodeList xmlItem = xmlDoc.GetElementsByTagName("item");

            StringBuilder sb = new StringBuilder();
            foreach (XmlNode node in xmlItem)
            {
                XmlNodeList li = node.ChildNodes;
                Story item = new Story();
                foreach (XmlNode n in li)
                {
                    /*
                        Word Cloud needed for categories
                    */

                    //url
                    if (n.Name.Equals("guid"))
                    {
                        item.Uri = n.InnerText;
                    }
                    //description
                    else if (n.Name.Equals("description"))
                    {
                        item.Description = n.InnerText;
                    }
                    //title
                    else if (n.Name.Equals("title"))
                    {
                        item.Title = n.InnerText;
                    }
                }
                NewsItems.Add(item);
            }
        }
    }
}
