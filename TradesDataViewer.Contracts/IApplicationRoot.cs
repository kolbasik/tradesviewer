// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The Application contract.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Contracts
{
    /// <summary>The Application contract.</summary>
    public interface IApplicationRoot
    {
        /// <summary>Gets the prism.</summary>
        IPrism Prism { get; }

        /// <summary>Gets the trade data pushed channel.</summary>
        TradeDataPushedEvent TradeDataPushedChannel { get; }

        /// <summary>Gets the notification channel.</summary>
        NotificationChannel NotificationChannel { get; }
    }
}