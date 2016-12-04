using NewsAggregator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.ViewModels
{
    class NwsFeedViewModel : NotificationBase
    {
        NwsPaper nwsPaper;
        public Boolean isActive;
        public String defText;
        public NwsFeedViewModel()
        { 
            //display text to user
            IsActive = true;
            DefText = "No stories displayed\nPlease add some more likes";
            asyncCreatePaper();
        }
        public async Task asyncCreatePaper()
        {
            nwsPaper = new NwsPaper();
            //get user's news paper
            await nwsPaper.getStories();
            IsActive = false;
            //check if user has news
            if(nwsPaper.Stories.Count>0)
            {
                //if user has news, remove text
                DefText = "";
            }
            _SelectedIndex = -1;
            // Load the database
            //randomise order of newspaper
            Random rnd = new Random();
            nwsPaper.Stories = nwsPaper.Stories.OrderBy(x => rnd.Next()).ToList();

            foreach (var story in nwsPaper.Stories)
            {
                var np = new StoryViewModel(story);
                _Story.Add(np);
            }
        }
        ObservableCollection<StoryViewModel> _Story = new ObservableCollection<StoryViewModel>();

        //observable collections and bound properties
        public ObservableCollection<StoryViewModel> StoryCollection
        {
            get { return _Story; }
            set { SetProperty(ref _Story, value); }
        }
        public Boolean IsActive
        {
            get { return isActive; }
            set
            {
                if (SetProperty(ref isActive, value))
                { RaisePropertyChanged(nameof(SelectedStory)); }
            }
        }
        public String DefText
        {
            get { return defText; }
            set
            {
                if (SetProperty(ref defText, value))
                { RaisePropertyChanged(nameof(SelectedStory)); }
            }
        }
        int _SelectedIndex;
        public int SelectedIndex
        {
            get { return _SelectedIndex; }
            set
            {
                if (SetProperty(ref _SelectedIndex, value))
                { RaisePropertyChanged(nameof(SelectedStory)); }
            }
        }
        public StoryViewModel SelectedStory
        {
            get { return (_SelectedIndex >= 0) ? _Story[_SelectedIndex] : null; }
        }
        //add story to story collection
        public void Add()
        {
            var story = new StoryViewModel();
            StoryCollection.Add(story);
            nwsPaper.Add(story);
            SelectedIndex = StoryCollection.IndexOf(story);
        }


    }
}