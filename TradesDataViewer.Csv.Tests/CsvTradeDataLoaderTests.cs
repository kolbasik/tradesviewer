// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The csv trade data loader tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Csv.Tests
{
    using System;
    using System.Linq;

    using TradesDataViewer.Contracts;

    using Xunit;

    public class CsvTradeDataLoaderTests
    {
        private readonly CsvTradeDataLoader loader;

        public CsvTradeDataLoaderTests()
        {
            this.loader = new CsvTradeDataLoader();
        }

        [Fact]
        public void Instance_Always_ImplementsTradeDataLoader()
        {
            // arrange & act
            var actual = this.loader;

            // assert
            Assert.IsAssignableFrom<ITradeDataLoader>(actual);
        }

        [Fact]
        public void Extension_Always_ReturnsXml()
        {
            // arrange
            var expected = ".csv";

            // act
            var actual = this.loader.Extension;

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Read_Always_ReturnsXml()
        {
            // arrange
            var xml = @"2013-5-20,30.16,30.39,30.02,30.17,1478200
2013-5-17,29.77,30.26,29.77,30.26,2481400 
2013-5-16,29.78,29.94,29.55,29.67,1077000 
2013-5-15,29.63,29.99,29.63,29.98,928700 
2013-5-14,29.53,29.77,29.48,29.6,1065900 
2013-5-13,29.33,29.59,29.09,29.51,1005800 
2013-5-10,29.89,29.91,29.52,29.83,1831000 
2013-5-9,29.65,29.68,29.2,29.3,1693600 
2013-5-8,29.65,29.99,29.54,29.72,1009800 
2013-5-7,29.46,29.62,29.18,29.49,1390200 
2013-5-6,28.8,28.9,28.64,28.78,744800 
2013-5-3,28.85,29.02,28.45,28.56,1087800 
2013-5-2,28.1,28.33,28,28.24,1472500 
2013-5-1,27.94,28.19,27.61,27.7,1006900";
            var expected_first = new TradeData { Date = new DateTime(2013, 5, 20), Open = 30.16m, High = 30.39m, Low = 30.02m, Close = 30.17m, Volume = 1478200 };
            var expected_last = new TradeData { Date = new DateTime(2013, 5, 1), Open = 27.94m, High = 28.19m, Low = 27.61m, Close = 27.7m, Volume = 1006900 };

            // act
            var actual = this.loader.Read(StreamHelper.GetStreamFrom(xml)).ToArray();

            // assert
            Assert.Equal(14, actual.Count());
            AssertTradeData(expected_first, actual.First());
            AssertTradeData(expected_last, actual.Last());
        }

        private static void AssertTradeData(TradeData expected, TradeData actual)
        {
            Assert.Equal(expected.Date, actual.Date);
            Assert.Equal(expected.Open, actual.Open);
            Assert.Equal(expected.High, actual.High);
            Assert.Equal(expected.Low, actual.Low);
            Assert.Equal(expected.Close, actual.Close);
            Assert.Equal(expected.Volume, actual.Volume);
        }
    }
}