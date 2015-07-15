// --------------------------------------------------------------------------------------------------------------------
// <summary>
//   The system directory watcher.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TradesDataViewer.Watcher.Core
{
    using System.Collections.Generic;

    using XDirectory = System.IO.Directory;

    /// <summary>The system watcher.</summary>
    internal class FileSystemWatcher
    {
        private readonly HashSet<string> files;

        private string directory;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileSystemWatcher"/> class.
        /// </summary>
        public FileSystemWatcher()
        {
            this.files = new HashSet<string>();
        }

        /// <summary>Gets or sets the directory.</summary>
        public string Directory
        {
            get { return this.directory; }
            set { this.directory = value; this.files.Clear(); }
        }

        /// <summary>Gets the newest files.</summary>
        /// <returns>The list of file pathes.</returns>
        public IEnumerable<string> GetNewestFiles()
        {
            var folder = this.directory;
            if (XDirectory.Exists(folder))
            {
                foreach (var file in XDirectory.EnumerateFiles(folder))
                {
                    if (this.files.Add(file))
                    {
                        yield return file;
                    }
                }
            }
        }
    }
}