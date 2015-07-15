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
        /// <summary>The timer.</summary>
        private readonly Timer timer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PollingTimer" /> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public PollingTimer(Action action)
        {
            this.timer = new Timer(TimeSpan.FromMinutes(1).TotalMilliseconds);
            this.timer.Elapsed += delegate { action(); };
            this.timer.Start();
        }

        /// <summary>Gets or sets the interval.</summary>
        public TimeSpan Interval
        {
            get { return TimeSpan.FromMilliseconds(this.timer.Interval); }
            set { this.timer.Interval = value.TotalMilliseconds; }
        }

        /// <summary>The dispose.</summary>
        public void Dispose()
        {
            this.timer.Stop();
            this.timer.Dispose();
        }
    }
}