using System.Windows.Input;
using StopWatch.ViewModel;

namespace StopWatch.View
{
    /// <summary>
    ///     Interaction logic for UCTime.xaml
    /// </summary>
    public partial class RecordTimeView
    {
        public RecordTimeView(RecordedTimeViewModel timeViewModel)
        {
            InitializeComponent();
            Time = timeViewModel;
            DataContext = Time;
        }

        private RecordedTimeViewModel Time { get; }

        private void MainGrid_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            Time.Selected = !Time.Selected;
        }
    }
}