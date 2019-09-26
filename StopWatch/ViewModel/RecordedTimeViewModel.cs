using System;
using GalaSoft.MvvmLight.Command;

namespace StopWatch.ViewModel
{
    public class RecordedTimeViewModel : NotifyPropertyChanged
    {
        public event EventHandler DeleteClicked;
        public event EventHandler SelectedClicked;
        private DateTime _time;
        private bool _selected;

        public RecordedTimeViewModel()
        {
            DeleteCommandClick = new RelayCommand(DeleteTime);
        }
        public RelayCommand DeleteCommandClick { get; set; }

        private void DeleteTime()
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        public DateTime Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged();
            }
        }

        public bool Selected
        {
            get => _selected;
            set
            {
                _selected = value;
                SelectedClicked?.Invoke(this, EventArgs.Empty);
                OnPropertyChanged();
            }
        }
    }
}
