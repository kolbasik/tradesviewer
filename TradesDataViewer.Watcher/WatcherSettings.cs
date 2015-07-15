// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The watcher settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Watcher
{
    using System;
    using System.ComponentModel.Composition;

    using Microsoft.Practices.Prism.Mvvm;

    /// <summary>The watcher settings.</summary>
    [Export, PartCreationPolicy(CreationPolicy.Shared)]
    public class WatcherSettings : BindableBase
    {
        /// <summary>The directory.</summary>
        private string directory;

        /// <summary>The interval.</summary>
        private TimeSpan interval;

        /// <summary>Initializes a new instance of the <see cref="WatcherSettings"/> class.</summary>
        public WatcherSettings()
        {
            this.Directory = @"C:\trades";
            this.Interval = TimeSpan.FromSeconds(30);
        }

        /// <summary>Gets or sets the directory.</summary>
        public string Directory
        {
            get { return this.directory; }
            set { this.SetProperty(ref this.directory, value); }
        }

        /// <summary>Gets or sets the interval.</summary>
        public TimeSpan Interval
        {
            get { return this.interval; }
            set { this.SetProperty(ref this.interval, value); }
        }
    }
}