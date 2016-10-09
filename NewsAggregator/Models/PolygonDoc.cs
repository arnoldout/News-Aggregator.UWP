using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NewsAggregator.Models
{
    class PolygonDoc : XmlDoc
    {
        public override async Task parseXml()
        {
            XmlDocument xmlDoc = await getXml("http://www.polygon.com/rss/index.xml");
            XmlNodeList items = xmlDoc.GetElementsByTagName("entry");

            StringBuilder sb = new StringBuilder();
            foreach (XmlNode node in items)
            {
                XmlNodeList li = node.ChildNodes;
                Story item = new Story();
                foreach (XmlNode n in li)
                {
                    /*
                        Word Cloud needed for categories
                    */

                    //url
                    if (n.Name.Equals("id"))
                    {
                        item.Uri = n.InnerText;
                    }
                    //description
                    else if (n.Name.Equals("content"))
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
