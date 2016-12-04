using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsAggregator.Models;
using System.Threading;
using NewsAggregator.Data;

namespace NewsAggregator.ViewModels
{
    class ResultViewModel : NotificationBase
    {
        public Boolean isActive;
        private Story parameters;
        public Uri uri;
        public ResultViewModel(Story parameters)
        {
            IsActive = true;
            this.parameters = parameters;
            String sUri = parameters.Uri;
            uri = (new Uri(sUri));
            AutoResetEvent waitForNavComplete = new AutoResetEvent(false);
            IsActive = true;
            ThreadNavigater(waitForNavComplete);
            
            //headerText.Text = parameters.Title;
            foreach (String s in parameters.Categories)
            {
                StoryService.addLike(s, App.loginid);
            }
        }
        
        public async Task ThreadNavigater(AutoResetEvent waitForNavComplete)
        {
            await Task.Delay(1000);
            IsActive = false;
            await Task.Run(() => { waitForNavComplete.WaitOne(); });
            waitForNavComplete.Reset();
            
        }

            public Boolean IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                RaisePropertyChanged("IsActive");
            }
        
    }
    }
}
