using NewsAggregator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.ViewModels
{
    class StoryViewModel : NotificationBase<Story>
    {
        //properties for story
        public StoryViewModel(Story story = null) : base(story) { }
        public String Title
        {
            get { return This.Title; }
            set { SetProperty(This.Title, value, () => This.Title = value); }
        }
        public String Description
        {
            get { return This.Description; }
            set { SetProperty(This.Description, value, () => This.Description = value); }
        }
        public String Uri
        {
            get { return This.Uri; }
            set { SetProperty(This.Uri, value, () => This.Uri = value); }
        }
        public List<String> Categories
        {
            get { return This.Categories; }
            set { SetProperty(This.Categories, value, () => This.Categories = value); }
        }
        public Uri ImgUri
        {
            get { return This.ImgUri; }
            set { SetProperty(This.ImgUri, value, () => This.ImgUri = value); }
        }
    }
}
