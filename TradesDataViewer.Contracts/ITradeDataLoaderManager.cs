// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The TradeDataLoaderManager interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Contracts
{
    /// <summary>The TradeDataLoaderManager interface.</summary>
    public interface ITradeDataLoaderManager
    {
        /// <summary>The get trade data loader.</summary>
        /// <param name="extension">The extension.</param>
        /// <returns>The <see cref="ITradeDataLoader"/>.</returns>
        ITradeDataLoader GetTradeDataLoader(string extension);
    }
}