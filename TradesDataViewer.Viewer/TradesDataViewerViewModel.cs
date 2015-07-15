// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The trades data viewer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Viewer
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel.Composition;

    using global::TradesDataViewer.Contracts;

    using Microsoft.Practices.Prism.Mvvm;
    using Microsoft.Practices.Prism.PubSubEvents;

    /// <summary>The trades data viewer view model.</summary>
    [Export, PartCreationPolicy(CreationPolicy.NonShared)]
    public class TradesDataViewerViewModel : BindableBase, IDisposable
    {
        /// <summary>The token.</summary>
        private readonly SubscriptionToken token;

        /// <summary>Initializes a new instance of the <see cref="TradesDataViewerViewModel"/> class.</summary>
        /// <param name="application">The application.</param>
        [ImportingConstructor]
        public TradesDataViewerViewModel(IApplicationRoot application)
        {
            this.TradeDataItems = new ObservableCollection<TradeData>();
            this.token = application.TradeDataPushedChannel.Subscribe(this.HandleTradeDataPushedEvent, ThreadOption.UIThread);
        }

        /// <summary>Gets the trade data items.</summary>
        public ObservableCollection<TradeData> TradeDataItems { get; private set; }

        /// <summary>The dispose.</summary>
        public void Dispose()
        {
            this.token.Dispose();
        }

        /// <summary>The handle trade data pushed event.</summary>
        /// <param name="trades">The trade data.</param>
        private void HandleTradeDataPushedEvent(TradeData[] trades)
        {
            foreach (var trade in trades)
            {
                this.TradeDataItems.Add(trade);
            }
        }
    }
}