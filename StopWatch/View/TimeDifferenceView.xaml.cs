using StopWatch.ViewModel;

namespace StopWatch.View
{
    /// <summary>
    /// Interaction logic for UCDifferenceRow.xaml
    /// </summary>
    public partial class TimeDifferenceView
    {
        public TimeDifferenceView(TimeDifferenceViewModel time)
        {
            InitializeComponent();
            DataContext = time;
        }
    }
}
