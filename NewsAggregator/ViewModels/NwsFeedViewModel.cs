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
            IsActive = true;
            DefText = "No stories displayed\nPlease add some more likes";
            asyncCreatePaper();
        }
        public async Task asyncCreatePaper()
        {
            nwsPaper = new NwsPaper();
            await nwsPaper.getStories();
            IsActive = false;
            if(nwsPaper.Stories.Count>0)
            {
               DefText = "";
            }
            _SelectedIndex = -1;
            // Load the database
            Random rnd = new Random();
            nwsPaper.Stories = nwsPaper.Stories.OrderBy(x => rnd.Next()).ToList();

            foreach (var story in nwsPaper.Stories)
            {
                var np = new StoryViewModel(story);
                np.PropertyChanged += Story_OnNotifyPropertyChanged;
                _Story.Add(np);
            }
        }
        ObservableCollection<StoryViewModel> _Story = new ObservableCollection<StoryViewModel>();

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
        public void Add()
        {
            var story = new StoryViewModel();
            story.PropertyChanged += Story_OnNotifyPropertyChanged;
            StoryCollection.Add(story);
            nwsPaper.Add(story);
            SelectedIndex = StoryCollection.IndexOf(story);
        }

        void Story_OnNotifyPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            nwsPaper.Update((StoryViewModel)sender);
        }
    }
}