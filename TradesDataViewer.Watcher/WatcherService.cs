// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The watcher service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Watcher
{
    using System;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Threading;

    using TradesDataViewer.Contracts;
    using TradesDataViewer.Watcher.Core;

    using XPath = System.IO.Path;
    using XFile = System.IO.File;

    /// <summary>The watcher service.</summary>
    [Export, PartCreationPolicy(CreationPolicy.Shared)]
    public class WatcherService
    {
        /// <summary>The application.</summary>
        private readonly IApplicationRoot application;

        /// <summary>The loader manager.</summary>
        private readonly ITradeDataLoaderManager loaderManager;

        /// <summary>Initializes a new instance of the <see cref="WatcherService"/> class.</summary>
        /// <param name="application">The application.</param>
        /// <param name="loaderManager">The loader manager.</param>
        [ImportingConstructor]
        public WatcherService(IApplicationRoot application, ITradeDataLoaderManager loaderManager)
        {
            this.application = application;
            this.loaderManager = loaderManager;

            this.Watcher = new FileSystemWatcher();
            this.Timer = new PollingTimer(this.Execute);
        }

        /// <summary>Gets the watcher.</summary>
        internal FileSystemWatcher Watcher { get; private set; }

        /// <summary>Gets the timer.</summary>
        internal PollingTimer Timer { get; private set; }

        /// <summary>Starts</summary>
        public void Start()
        {
            this.Timer.Start();
        }

        /// <summary>The change settings.</summary>
        /// <param name="directory">The directory.</param>
        /// <param name="interval">The interval.</param>
        public void ChangeSettings(string directory, TimeSpan interval)
        {
            this.Watcher.Directory = directory;
            this.Timer.Interval = interval;
        }

        private void Execute()
        {
            foreach (var file in this.Watcher.GetNewestFiles())
            {
                ThreadPool.QueueUserWorkItem(state => this.HandleFile((string)state), file);
            }
        }

        private void HandleFile(string file)
        {
            var loader = this.loaderManager.GetTradeDataLoader(XPath.GetExtension(file));
            if (loader != null)
            {
                using (var stream = XFile.OpenRead(file))
                {
                    var trades = loader.Read(stream).ToArray();
                    var channel = this.application.TradeDataPushedChannel;
                    channel.Publish(trades);
                }
            }
        }
    }
}