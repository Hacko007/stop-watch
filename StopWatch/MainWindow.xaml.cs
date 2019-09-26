using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using StopWatch.ViewModel;

namespace StopWatch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<RecordedTimeViewModel> RecordedTimes { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            RecordedTimes = recordedTimesView.Items;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowClock();
        }

        private async void ShowClock()
        {
            var progress = new Progress<DateTime>(
                i => ClockLabel.Content = i.ToString("HH:mm:ss.ff"));

            await Task.Run(() => DoWork(progress));
        }

        private async void DoWork(IProgress<DateTime> progress)
        {
            while (true)
            {
                progress.Report(DateTime.Now);
                await Task.Delay(10);
            }
        }

        private void ClockLabel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddClickedTime();
        }

        private void AddClickedTime()
        {
            var time = new RecordedTimeViewModel() { Time = DateTime.Now };
            RecordedTimes.Add(time);
            time.DeleteClicked += TimeDeleteClicked;
            time.SelectedClicked += TimeSelectedClicked;
        }

        private void TimeSelectedClicked(object sender, EventArgs e)
        {
            var item = sender as RecordedTimeViewModel;
            selectedTimesView.UpdateSelectedTimes(item);
            selectedTimesView.BuildGrid();

        }

        private void TimeDeleteClicked(object sender, EventArgs e)
        {
            var item = sender as RecordedTimeViewModel;
            item.Selected = false;
            selectedTimesView.UpdateSelectedTimes(item);
            selectedTimesView.BuildGrid();
            RecordedTimes.Remove(item);

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed && e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
