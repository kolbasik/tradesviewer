// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The csv trade data loader.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TradesDataViewer.Csv
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.IO;
    using System.Text;

    using TradesDataViewer.Contracts;

    /// <summary>The xml trade data loader.</summary>
    [Export(typeof(ITradeDataLoader))]
    public class CsvTradeDataLoader : ITradeDataLoader
    {
        /// <summary>
        ///     Gets the extension.
        /// </summary>
        /// <value>
        ///     The extension.
        /// </value>
        public string Extension
        {
            get
            {
                return ".csv";
            }
        }

        /// <summary>The read.</summary>
        /// <param name="stream">The stream/</param>
        /// <returns>The <see cref="IEnumerable{TradeData}"/> trade data.</returns>
        public IEnumerable<TradeData> Read(Stream stream)
        {
            var reader = new StreamReader(stream, Encoding.UTF8);
            string line = null;
            while ((line = reader.ReadLine()) != null)
            {
                var node = line.Split(',');
                var trade = new TradeData();
                trade.Date = DateTime.Parse(node[0]);
                trade.Open = decimal.Parse(node[1]);
                trade.High = decimal.Parse(node[2]);
                trade.Low = decimal.Parse(node[3]);
                trade.Close = decimal.Parse(node[4]);
                trade.Volume = decimal.Parse(node[5]);
                yield return trade;
            }
        }
    }
}