using System.Collections.ObjectModel;

namespace StopWatch.ViewModel
{
    public class RecordedTimesViewModel : NotifyPropertyChanged
    {
        private ObservableCollection<RecordedTimeViewModel> _items;

        public RecordedTimesViewModel()
        {
            Items = new ObservableCollection<RecordedTimeViewModel>();
        }

        public ObservableCollection<RecordedTimeViewModel> Items
        {
            get => _items;
            private set
            {
                if (Equals(value, _items))
                {
                    return;
                }
                _items = value;
                OnPropertyChanged();
            }
        }
    }
}