using System;
using System.Collections.Generic;
using StopWatch.ViewModel;

namespace StopWatch.View
{
    /// <summary>
    ///     Interaction logic for UCDifferences.xaml
    /// </summary>
    public partial class DifferencesListView
    {
        public DifferencesListView()
        {
            InitializeComponent();
            SelectedTimes = new List<DateTime>();
        }

        private List<DateTime> SelectedTimes { get; }

        public void BuildGrid()
        {
            SelectedTimes.Sort();
            MainSackPanel.Children.Clear();

            for (var index = SelectedTimes.Count - 1; index >= 0; index--)
            {
                var toTime = SelectedTimes[index];
                for (var i = 0; i < index; i++)
                {
                    var fromTime = SelectedTimes[i];
                    var diff = new TimeDifferenceViewModel { FromTime = fromTime, ToTime = toTime };
                    var row = new TimeDifferenceView(diff);

                    MainSackPanel.Children.Add(row);
                }
            }
        }

        public void UpdateSelectedTimes(RecordedTimeViewModel item)
        {
            if (!SelectedTimes.Contains(item.Time) && item.Selected)
            {
                SelectedTimes.Add(item.Time);
            }
            else if (SelectedTimes.Contains(item.Time) && !item.Selected)
            {
                SelectedTimes.Remove(item.Time);
            }
        }

    }
}