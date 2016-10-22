using NewsAggregator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Models
{
    class NwsPaper
    {
        public List<Story> Stories { get; set; }
        public NwsPaper()
        {
            getStories();
        }
        public async Task getStories()
        {
            Stories = await StoryService.getStories(App.loginid);
        }
        public void addLike(String like)
        {
            StoryService.addLike(like, App.loginid);
        }

    }
}
