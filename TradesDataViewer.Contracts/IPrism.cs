// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The Prism interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Contracts
{
    using Microsoft.Practices.Prism.Logging;
    using Microsoft.Practices.Prism.PubSubEvents;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;

    /// <summary>The Prism interface.</summary>
    public interface IPrism
    {
        /// <summary>
        ///     Gets the region manager. Registers and retrieves regions, which are visual containers for layout.
        /// </summary>
        /// <value>
        ///     The region manager.
        /// </value>
        IRegionManager RegionManager { get; }

        /// <summary>
        ///     Gets the event aggregator. A collection of events that is loosely coupled between the publisher and the subscriber.
        /// </summary>
        /// <value>
        ///     The event aggregator.
        /// </value>
        IEventAggregator EventAggregator { get; }

        /// <summary>
        ///     Gets the logger facade. A wrapper for a logging mechanism, so you can choose your own logging mechanism. The Stock
        ///     Trader Reference Implementation (Stock Trader RI) uses the Enterprise Library Logging Application Block, via the
        ///     EnterpriseLibraryLoggerAdapter class, as an example of how you can use your own logger. The logging service is
        ///     registered with the container by the bootstrapper's Run method, using the value returned by the CreateLogger
        ///     method. Registering another logger with the container will not work; instead override the CreateLogger method on
        ///     the bootstrapper.
        /// </summary>
        /// <value>
        ///     The logger facade.
        /// </value>
        ILoggerFacade LoggerFacade { get; }

        /// <summary>
        ///     Gets the service locator. Allows the Prism Library to access the container. If you want to customize or extend the
        ///     library, this may be useful.
        /// </summary>
        /// <value>
        ///     The service locator.
        /// </value>
        IServiceLocator ServiceLocator { get; }
    }
}