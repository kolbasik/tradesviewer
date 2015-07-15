// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The xml trade data loader tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Xml.Tests
{
    using System;
    using System.Linq;

    using TradesDataViewer.Contracts;

    using Xunit;

    /// <summary>The xml trade data loader tests.</summary>
    public class XmlTradeDataLoaderTests
    {
        private readonly XmlTradeDataLoader loader;

        public XmlTradeDataLoaderTests()
        {
            this.loader = new XmlTradeDataLoader();
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
            var expected = ".xml";

            // act
            var actual = this.loader.Extension;

            // assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Read_Always_ReturnsXml()
        {
            // arrange
            var xml = @"<?xml version=""1.0"" encoding=""utf-8"" ?> 
<values> 
 <value date=""2013-5-20"" open=""30.16"" high=""30.39"" low=""30.02"" close=""30.17"" volume=""1478200"" /> 
 <value date=""2013-5-17"" open=""29.77"" high=""30.26"" low=""29.77"" close=""30.26"" volume=""2481400"" /> 
 <value date=""2013-5-16"" open=""29.78"" high=""29.94"" low=""29.55"" close=""29.67"" volume=""1077000"" /> 
 <value date=""2013-5-15"" open=""29.63"" high=""29.99"" low=""29.63"" close=""29.98"" volume=""928700"" /> 
 <value date=""2013-5-14"" open=""29.53"" high=""29.77"" low=""29.48"" close=""29.6"" volume=""1065900"" /> 
 <value date=""2013-5-13"" open=""29.33"" high=""29.59"" low=""29.09"" close=""29.51"" volume=""1005800"" /> 
 <value date=""2013-5-10"" open=""29.89"" high=""29.91"" low=""29.52"" close=""29.83"" volume=""1831000"" /> 
 <value date=""2013-5-9"" open=""29.65"" high=""29.68"" low=""29.2"" close=""29.3"" volume=""1693600"" /> 
 <value date=""2013-5-8"" open=""29.65"" high=""29.99"" low=""29.54"" close=""29.72"" volume=""1009800"" /> 
 <value date=""2013-5-7"" open=""29.46"" high=""29.62"" low=""29.18"" close=""29.49"" volume=""1390200"" /> 
 <value date=""2013-5-6"" open=""28.8"" high=""28.9"" low=""28.64"" close=""28.78"" volume=""744800"" /> 
 <value date=""2013-5-3"" open=""28.85"" high=""29.02"" low=""28.45"" close=""28.56"" volume=""1087800"" /> 
 <value date=""2013-5-2"" open=""28.1"" high=""28.33"" low=""28"" close=""28.24"" volume=""1472500"" /> 
 <value date=""2013-5-1"" open=""27.94"" high=""28.19"" low=""27.61"" close=""27.7"" volume=""1006900"" /> 
</values>";
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