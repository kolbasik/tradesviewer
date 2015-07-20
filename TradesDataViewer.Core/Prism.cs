// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The prism.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Core
{
    using System.ComponentModel.Composition;

    using Microsoft.Practices.Prism.Logging;
    using Microsoft.Practices.Prism.PubSubEvents;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;

    using TradesDataViewer.Contracts;

    /// <summary>The prism.</summary>
    [Export(typeof(IPrism))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class Prism : IPrism
    {
        /// <summary>Gets or sets the region manager.</summary>
        [Import]
        public IRegionManager RegionManager { get; set; }

        /// <summary>Gets or sets the event aggregator.</summary>
        [Import]
        public IEventAggregator EventAggregator { get; set; }

        /// <summary>Gets or sets the logger facade.</summary>
        [Import]
        public ILoggerFacade LoggerFacade { get; set; }

        /// <summary>Gets or sets the service locator.</summary>
        [Import]
        public IServiceLocator ServiceLocator { get; set; }
    }
}