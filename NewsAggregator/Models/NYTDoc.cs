using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NewsAggregator.Models
{
    public class NYTDoc : XmlDoc
    {
        public override async Task parseXml()
        {
            XmlDocument xmlDoc = await getXml("http://rss.nytimes.com/services/xml/rss/nyt/HomePage.xml");
            XmlNodeList items = xmlDoc.GetElementsByTagName("item");

            StringBuilder sb = new StringBuilder();
            foreach (XmlNode node in items)
            {
                XmlNodeList li = node.ChildNodes;
                Story item = new Story();
                foreach (XmlNode n in li)
                {
                    if (n.Name.Equals("category"))
                    {
                        item.Categories.Add(n.InnerText);
                    }
                    else if (n.Name.Equals("guid"))
                    {
                        item.Uri = n.InnerText;
                    }
                    else if (n.Name.Equals("description"))
                    {
                        item.Description = n.InnerText;
                    }
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
