using NewsAggregator.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsAggregator.ViewModels;

namespace NewsAggregator.Models
{
    class NwsPaper
    {
        public List<Story> Stories { get; set; }
        
        public NwsPaper()
        {
            Stories = new List<Story>();
        }
        public async Task getStories()
        {            
            Stories = await StoryService.getStories(App.loginid);
        }
        
        public void addLike(String like)
        {
            StoryService.addLike(like, App.loginid);
        }

        internal void Add(Story story)
        {
            if (!Stories.Contains(story)) { 
                Stories.Add(story);
            }
        }

        internal void Update(Story sender)
        {
            StoryService.update(sender);
        }
    }
}
