// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   Interaction for Shell.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TradesDataViewer.WpfApp
{
    using System.ComponentModel.Composition;
    using System.Windows;

    /// <summary>
    ///     Interaction logic for Shell.xaml
    /// </summary>
    [Export]
    public partial class Shell : Window
    {
        /// <summary>Initializes a new instance of the <see cref="Shell" /> class.</summary>
        public Shell()
        {
            this.InitializeComponent();
        }
    }
}