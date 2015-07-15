// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The trade data pushed event.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Contracts
{
    using Microsoft.Practices.Prism.PubSubEvents;

    /// <summary>The trade data pushed event.</summary>
    public class TradeDataPushedEvent : PubSubEvent<TradeData[]>
    {
    }
}