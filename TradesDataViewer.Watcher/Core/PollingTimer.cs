// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The polling timer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Watcher.Core
{
    using System;
    using System.Timers;

    /// <summary>The polling timer.</summary>
    internal class PollingTimer : IDisposable
    {
        private readonly Action action;

        private readonly Timer timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PollingTimer" /> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public PollingTimer(Action action)
        {
            this.action = action;
            this.timer = new Timer(TimeSpan.FromMinutes(1).TotalMilliseconds);
            this.timer.Elapsed += delegate { this.action(); };
        }

        /// <summary>Gets or sets the interval.</summary>
        public TimeSpan Interval
        {
            get { return TimeSpan.FromMilliseconds(this.timer.Interval); }
            set { this.timer.Interval = value.TotalMilliseconds; }
        }

        /// <summary>Starts the polling.</summary>
        public void Start()
        {
            this.action();
            this.timer.Start();
        }

        /// <summary>The dispose.</summary>
        public void Dispose()
        {
            this.timer.Stop();
            this.timer.Dispose();
        }
    }
}