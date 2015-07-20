// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The notification channel.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Contracts
{
    using Microsoft.Practices.Prism.PubSubEvents;

    /// <summary>The notification channel.</summary>
    public sealed class NotificationChannel : PubSubEvent<Notification>
    {
    }
}