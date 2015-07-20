// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Interaction for Shell.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TradesDataViewer.WpfApp
{
    using System;
    using System.ComponentModel.Composition;
    using System.Windows;

    using MahApps.Metro.Controls;
    using MahApps.Metro.Controls.Dialogs;

    using Microsoft.Practices.Prism.PubSubEvents;

    using TradesDataViewer.Contracts;

    [Export]
    public partial class Shell : MetroWindow
    {
        private readonly SubscriptionToken token;

        /// <summary>Initializes a new instance of the <see cref="Shell" /> class.</summary>
        [ImportingConstructor]
        public Shell(IApplicationRoot application)
        {
            this.InitializeComponent();
            this.token = application.NotificationChannel.Subscribe(this.NotificationChannel_OnNotify);
            this.Closed += this.Window_OnClosed;
        }

        private void Window_OnClosed(object sender, EventArgs eventArgs)
        {
            this.token.Dispose();
        }

        private void NotificationChannel_OnNotify(Notification notification)
        {
            this.ShowMessageAsync(notification.Title, notification.Message);
        }

        private void SettingsToggle_OnClick(object sender, RoutedEventArgs e)
        {
            this.SettingsFlyout.IsOpen = !this.SettingsFlyout.IsOpen;
        }
    }
}