// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Interaction for Shell.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TradesDataViewer.WpfApp
{
    using System.ComponentModel.Composition;
    using System.Windows;

    using MahApps.Metro.Controls;

    [Export]
    public partial class Shell : MetroWindow
    {
        /// <summary>Initializes a new instance of the <see cref="Shell" /> class.</summary>
        public Shell()
        {
            this.InitializeComponent();
        }

        private void SettingsToggle_OnClick(object sender, RoutedEventArgs e)
        {
            this.SettingsFlyout.IsOpen = !this.SettingsFlyout.IsOpen;
        }
    }
}