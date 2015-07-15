// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The system watcher module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Watcher
{
    using System.ComponentModel.Composition;

    using Microsoft.Practices.Prism.MefExtensions.Modularity;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;

    using TradesDataViewer.Contracts;

    [ModuleExport("SystemWatcherModule", typeof(IModule))]
    public class SystemWatcherModule : IModule
    {
        private readonly IApplicationRoot application;

        [ImportingConstructor]
        public SystemWatcherModule(IApplicationRoot application)
        {
            this.application = application;
        }

        public void Initialize()
        {
            this.application.Prism.RegionManager.RegisterViewWithRegion("AsideRegion", typeof(SystemWatcherView));
        }
    }
}