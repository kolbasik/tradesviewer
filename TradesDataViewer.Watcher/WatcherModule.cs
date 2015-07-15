// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The watcher module.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Watcher
{
    using System.ComponentModel.Composition;

    using Microsoft.Practices.Prism.MefExtensions.Modularity;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;

    using TradesDataViewer.Contracts;

    [ModuleExport("WatcherModule", typeof(IModule), DependsOnModuleNames = new[] { "ViewerModule" })]
    public class WatcherModule : IModule
    {
        private readonly IApplicationRoot application;

        private readonly WatcherService service;

        [ImportingConstructor]
        public WatcherModule(IApplicationRoot application, WatcherService service)
        {
            this.application = application;
            this.service = service;
        }

        public void Initialize()
        {
            this.application.Prism.RegionManager.RegisterViewWithRegion("AsideRegion", typeof(WatcherView));
            this.service.Start();
        }
    }
}