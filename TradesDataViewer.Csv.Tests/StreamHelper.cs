// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The stream helper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Csv.Tests
{
    using System.IO;

    /// <summary>The stream helper.</summary>
    public static class StreamHelper
    {
        /// <summary>The get stream from.</summary>
        /// <param name="text">The text.</param>
        /// <returns>The <see cref="Stream"/>.</returns>
        public static Stream GetStreamFrom(string text)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(text);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}