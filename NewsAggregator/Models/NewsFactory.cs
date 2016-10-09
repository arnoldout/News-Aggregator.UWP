using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NewsAggregator.Models
{
    public class NewsFactory
    {
        public List<XmlDoc> docs = new List<XmlDoc>
        {
            new NYTDoc(),
            new PolygonDoc(),
            new BBCDoc()
        };

        public List<XmlDoc> Docs
        {
            get
            {
                return docs;
            }

            set
            {
                docs = value;
            }
        }

        public async Task getDocs()
        {
            List<Task> runningThreads = new List<Task>();
            foreach (XmlDoc d in Docs)
            {
                runningThreads.Add(Task.Factory.StartNew(() => d.parseXml()));
            }
            await Task.WhenAll(runningThreads.ToArray());
        }
    }
}
