// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The trade data loader manager.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Core
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;
    using System.Linq;

    using TradesDataViewer.Contracts;

    /// <summary>The trade data loader manager.</summary>
    [Export(typeof(ITradeDataLoaderManager)), PartCreationPolicy(CreationPolicy.Shared)]
    public class TradeDataLoaderManager : ITradeDataLoaderManager
    {
        private readonly Dictionary<string, ITradeDataLoader> loaders;

        [ImportingConstructor]
        public TradeDataLoaderManager([ImportMany(typeof(ITradeDataLoader))] IEnumerable<ITradeDataLoader> loaders)
        {
            this.loaders = loaders.ToDictionary(x => x.Extension);
        }

        public ITradeDataLoader GetTradeDataLoader(string extension)
        {
            ITradeDataLoader loader;
            this.loaders.TryGetValue(extension, out loader);
            return loader;
        }
    }
}