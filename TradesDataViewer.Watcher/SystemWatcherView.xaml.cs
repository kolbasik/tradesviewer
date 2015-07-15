// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Interaction logic for SystemWatcherView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Watcher
{
    using System.ComponentModel.Composition;
    using System.Windows.Controls;

    using Microsoft.Practices.Prism.Mvvm;

    /// <summary>
    ///     Interaction logic for SystemWatcherView.xaml
    /// </summary>
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class SystemWatcherView : UserControl, IView
    {
        /// <summary>Initializes a new instance of the <see cref="SystemWatcherView"/> class.</summary>
        [ImportingConstructor]
        public SystemWatcherView(SystemWatcherViewModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}