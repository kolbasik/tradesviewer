// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Interaction logic for TradesDataViewerView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Viewer
{
    using System.ComponentModel.Composition;
    using System.Windows.Controls;

    using Microsoft.Practices.Prism.Mvvm;

    /// <summary>
    ///     Interaction logic for TradesDataViewer.xaml
    /// </summary>
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class TradesDataViewerView : UserControl, IView
    {
        /// <summary>Initializes a new instance of the <see cref="TradesDataViewerView"/> class.</summary>
        [ImportingConstructor]
        public TradesDataViewerView(TradesDataViewerViewModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}