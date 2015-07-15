// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Interaction logic for WatcherView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Watcher
{
    using System.ComponentModel.Composition;
    using System.Windows.Controls;

    using Microsoft.Practices.Prism.Mvvm;

    /// <summary>
    ///     Interaction logic for WatcherView.xaml
    /// </summary>
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class WatcherView : UserControl, IView
    {
        /// <summary>Initializes a new instance of the <see cref="WatcherView"/> class.</summary>
        [ImportingConstructor]
        public WatcherView(WatcherViewModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}