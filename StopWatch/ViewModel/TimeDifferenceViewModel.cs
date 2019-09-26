using System;

namespace StopWatch.ViewModel
{
    public class TimeDifferenceViewModel
    {
        public DateTime FromTime { private get; set; }
        public DateTime ToTime { private get; set; }
        public TimeSpan DiffTime => ToTime - FromTime;

    }
}
