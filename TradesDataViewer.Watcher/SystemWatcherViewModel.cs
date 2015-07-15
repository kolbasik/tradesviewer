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
    public class SystemWatcherViewModel : BindableBase, IDisposable
    {
        /// <summary>Initializes a new instance of the <see cref="SystemWatcherViewModel"/> class.</summary>
        [ImportingConstructor]
        public SystemWatcherViewModel(SystemWatcherService service, SystemWatcherSettings settings)
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

        public SystemWatcherService Service { get; private set; }

        public SystemWatcherSettings Settings { get; private set; }

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