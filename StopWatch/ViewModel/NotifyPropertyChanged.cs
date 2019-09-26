using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace StopWatch.ViewModel
{
    public class NotifyPropertyChanged : ApplicationSettingsBase
    {

        public virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            OnPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}