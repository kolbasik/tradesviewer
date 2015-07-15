// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The application root.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TradesDataViewer.Contracts
{
    using System.ComponentModel.Composition;

    /// <summary>The application root.</summary>
    [Export(typeof(IApplicationRoot))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class ApplicationRoot : IApplicationRoot
    {
        /// <summary>Initializes a new instance of the <see cref="ApplicationRoot"/> class.</summary>
        /// <param name="prism">The prism.</param>
        [ImportingConstructor]
        public ApplicationRoot(IPrism prism)
        {
            this.Prism = prism;
            this.TradeDataPushedChannel = this.Prism.EventAggregator.GetEvent<TradeDataPushedEvent>();
        }

        /// <summary>Gets the prism.</summary>
        public IPrism Prism { get; private set; }

        /// <summary>Gets the trade data pushed channel.</summary>
        public TradeDataPushedEvent TradeDataPushedChannel { get; private set; }
    }
}