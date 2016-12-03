using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsAggregator.Models;

namespace NewsAggregator.ViewModels
{
    class ResultViewModel : NotificationBase
    {
        public Boolean isActive;
        private Story parameters;
        
        public ResultViewModel(Story parameters)
        {
            IsActive = true;
            waiter();
            this.parameters = parameters;
        }

        public async Task waiter()
        {
            await Task.Delay(5000);
            IsActive = false;
        }
        public Boolean IsActive
        {
            get { return isActive; }
            set { SetProperty(IsActive, value, () => IsActive= value); }
        }
    }
}
