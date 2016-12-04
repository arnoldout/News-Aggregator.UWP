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
            uri = (new Uri(parameters.Uri));

            foreach (String s in parameters.Categories)
            {
                StoryService.addLike(s, App.loginid);
            }
        }
        public void switchIsActive()
        {
            IsActive = (IsActive)? false: true;
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
        public Uri Uri
        {
            get { return uri; }
            set
            {
                uri = value;
                RaisePropertyChanged("Uri");
            }
        }
    }
}
