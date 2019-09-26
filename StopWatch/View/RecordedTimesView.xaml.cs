using System.Collections.ObjectModel;
using StopWatch.ViewModel;

namespace StopWatch.View
{
    /// <summary>
    /// Interaction logic for RecordedTimes.xaml
    /// </summary>
    public partial class RecordedTimesView
    {
        public RecordedTimesView() : this(new RecordedTimesViewModel())
        {
        }

        private RecordedTimesView(RecordedTimesViewModel items)
        {
            InitializeComponent();
            Items = items.Items;
            Items.CollectionChanged += Items_CollectionChanged;
        }

        public ObservableCollection<RecordedTimeViewModel> Items { get; }

        private void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            HistroyWrapGrid.Children.Clear();
            foreach (var item in Items)
            {
                var control = new RecordTimeView(item);
                HistroyWrapGrid.Children.Add(control);
            }
        }

    }
}
