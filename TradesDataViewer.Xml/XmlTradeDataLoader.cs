// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The xml trade data loader.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace TradesDataViewer.Xml
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Globalization;
    using System.IO;
    using System.Xml.Linq;
    using System.Xml.XPath;

    using TradesDataViewer.Contracts;

    /// <summary>The xml trade data loader.</summary>
    [Export(typeof(ITradeDataLoader))]
    public class XmlTradeDataLoader : ITradeDataLoader
    {
        private readonly CultureInfo culture = CultureInfo.InvariantCulture;

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
                return ".xml";
            }
        }

        /// <summary>The read.</summary>
        /// <param name="stream">The stream/</param>
        /// <returns>The <see cref="IEnumerable{TradeData}"/> trade data.</returns>
        public IEnumerable<TradeData> Read(Stream stream)
        {
            var document = XDocument.Load(stream);
            var nodes = document.XPathSelectElements(@"/values/value");
            foreach (var node in nodes)
            {
                var trade = new TradeData();
                trade.Date = DateTime.Parse(node.Attribute("date").Value, this.culture);
                trade.Open = decimal.Parse(node.Attribute("open").Value, this.culture);
                trade.High = decimal.Parse(node.Attribute("high").Value, this.culture);
                trade.Low = decimal.Parse(node.Attribute("low").Value, this.culture);
                trade.Close = decimal.Parse(node.Attribute("close").Value, this.culture);
                trade.Volume = decimal.Parse(node.Attribute("volume").Value, this.culture);
                yield return trade;
            }
        }
    }
}