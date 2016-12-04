using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NewsAggregator.ViewModels
{
    class LoginViewModel : NotificationBase
    {
        //boolean controls progress bar
        public Boolean isActive;
        public Boolean IsActive
        {
            get { return isActive; }
            set
            {
                isActive = value;
                RaisePropertyChanged("IsActive");
            }
        }
        public void switchIsActive()
        {
            IsActive = (IsActive) ? false : true;
        }
    }
}
