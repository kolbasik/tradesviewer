// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The viewer module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Viewer
{
    using System.ComponentModel.Composition;

    using global::TradesDataViewer.Contracts;

    using Microsoft.Practices.Prism.MefExtensions.Modularity;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;

    [ModuleExport("ViewerModule", typeof(IModule))]
    public class ViewerModule : IModule
    {
        private readonly IApplicationRoot application;

        [ImportingConstructor]
        public ViewerModule(IApplicationRoot application)
        {
            this.application = application;
        }

        public void Initialize()
        {
            this.application.Prism.RegionManager.RegisterViewWithRegion("ContentRegion", typeof(ViewerView));
        }
    }
}