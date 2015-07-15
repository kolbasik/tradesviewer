// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Interaction logic for ViewerView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Viewer
{
    using System.ComponentModel.Composition;
    using System.Windows.Controls;

    using Microsoft.Practices.Prism.Mvvm;

    /// <summary>
    ///     Interaction logic for ViewerView.xaml
    /// </summary>
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public partial class ViewerView : UserControl, IView
    {
        /// <summary>Initializes a new instance of the <see cref="ViewerView"/> class.</summary>
        [ImportingConstructor]
        public ViewerView(ViewerViewModel viewModel)
        {
            this.InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}