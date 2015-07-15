// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The trade data loader.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Contracts
{
    using System.Collections.Generic;
    using System.IO;

    public interface ITradeDataLoader
    {
        string Extension { get; }

        IEnumerable<TradeData> Read(Stream stream);
    }
}