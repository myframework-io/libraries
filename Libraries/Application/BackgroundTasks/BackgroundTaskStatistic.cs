using System;

namespace Myframework.Libraries.Application.BackgroundTasks
{
    public class BackgroundTaskStatistic
    {
        private double sumRuntime;
        private DateTime startStatistic = DateTime.Today;

        public string Name { get; set; }
        public DateTime StartDate { get; internal set; }
        public TimeSpan TimerInterval { get; internal set; }
        public long RunCount { get; internal set; }
        public long ErrorsCount { get; internal set; }
        public bool Enabled { get; internal set; }
        public TimeSpan? AverageRuntime => TimeSpan.FromMilliseconds((sumRuntime * 1000) / RunCount);
        public TimeSpan? BestRuntime { get; private set; }
        public TimeSpan? WorstRuntime { get; private set; }
        public DateTime? LastRuntime { get; set; }

        internal void AddError()
        {
            if (ErrorsCount == long.MaxValue || DateTime.Today > startStatistic.Date)
                ResetStatistic();

            ErrorsCount++;
        }

        internal void UpdateRun(long elapsedMilliseconds)
        {
            if (sumRuntime == long.MaxValue || RunCount == long.MaxValue || DateTime.Today > startStatistic.Date)
                ResetStatistic();

            var elapsedTimespan = TimeSpan.FromMilliseconds(elapsedMilliseconds);

            if (!BestRuntime.HasValue || elapsedTimespan < BestRuntime)
                BestRuntime = elapsedTimespan;

            if (!WorstRuntime.HasValue || elapsedTimespan > WorstRuntime)
                WorstRuntime = elapsedTimespan;

            sumRuntime += (elapsedMilliseconds / 1000);
            RunCount++;
        }

        private void ResetStatistic()
        {
            startStatistic = DateTime.Today;
            sumRuntime = 0;
            RunCount = 0;
            ErrorsCount = 0;
            BestRuntime = null;
            WorstRuntime = null;
            LastRuntime = null;
        }
    }
}