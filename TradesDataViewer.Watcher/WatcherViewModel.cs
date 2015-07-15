// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The system watcher view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Watcher
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Composition;

    using Microsoft.Practices.Prism.Mvvm;

    /// <summary>The system watcher view model.</summary>
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class WatcherViewModel : BindableBase, IDisposable
    {
        /// <summary>Initializes a new instance of the <see cref="WatcherViewModel"/> class.</summary>
        [ImportingConstructor]
        public WatcherViewModel(WatcherService service, WatcherSettings settings)
        {
            this.Service = service;
            this.Settings = settings;
            this.Settings.PropertyChanged += this.OnSettingsChanged;
            this.ApplySettings();
        }

        public void Dispose()
        {
            this.Settings.PropertyChanged -= this.OnSettingsChanged;
        }

        public WatcherService Service { get; private set; }

        public WatcherSettings Settings { get; private set; }

        private void OnSettingsChanged(object sender, PropertyChangedEventArgs args)
        {
            this.ApplySettings();
        }

        private void ApplySettings()
        {
            var settings = this.Settings;
            this.Service.ChangeSettings(settings.Directory, settings.Interval);
        }
    }
}