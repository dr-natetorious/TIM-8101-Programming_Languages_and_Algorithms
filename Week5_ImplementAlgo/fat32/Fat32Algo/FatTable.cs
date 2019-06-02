using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Fat32Algo
{
    /// <summary>
    /// Implements a File Allocation Table
    /// 
    /// It supports:
    /// - <see cref="WriteFile(string, string)"/> to create a file
    /// - <see cref="ReadFile(string)"/> to retrive the file
    /// - <see cref="DeleteFile(string)"/> to release the resources
    /// 
    /// When a file is persisted into the FAT it is broken into pages
    /// 
    /// If a file spans multiple pages then it uses a linked list structure 
    /// to find the next file entry.
    /// </summary>
    partial class FatTable
    {
        /// <summary>
        /// Gets the cached starting point to look for the next page
        /// </summary>
        private int nextFreePage = 0;

        private Queue<int> dirtyPages = new Queue<int>();

        /// <summary>
        /// Gets the entries within the table.
        /// </summary>
        public FileEntry[] Entries { get; }

        /// <summary>
        /// Get the maximum content length that can be held in a single <see cref="FileEntry"/>.
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Gets a map of filenames to their head node.
        /// </summary>
        public Dictionary<string, int> FileNames { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FatTable"/> class.
        /// </summary>
        /// <param name="maxBlocks">The number of file entries within the table</param>
        /// <param name="pageSize">The size of each <see cref="FileEntry.Page"/>.</param>
        public FatTable(int maxBlocks, int pageSize)
        {
            this.Entries = new FileEntry[maxBlocks];
            this.FileNames = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            this.PageSize = pageSize;

            for (var ix = 0; ix < maxBlocks; ix++)
            {
                this.Entries[ix] = new FileEntry(ix);
            }
        }

        /// <summary>
        /// Persists the <paramref name="contents"/> into the <see cref="FatTable.Entries"/>.
        /// </summary>
        /// <param name="fileName">The name of the file</param>
        /// <param name="contents">The contents to be stored.</param>
        public void WriteFile(string fileName, string contents)
        {
            if (this.FileNames.ContainsKey(fileName))
            {
                this.DeleteFile(fileName);
            }

            FileEntry head = null;
            foreach (var page in GetPages(contents))
            {
                var entry = GetNextFreeEntry();
                entry.Page = page;
                entry.NextPage = null;
                entry.Busy = true;

                if (head == null)
                {
                    this.FileNames.Add(fileName, entry.Id);
                }
                else
                {
                    head.NextPage = entry.Id;
                }

                head = entry;
            }

            head.NextPage = FileEntry.EndOfFileChar;
        }

        /// <summary>
        /// Retreives the file from the <see cref="FatTable.Entries"/>.
        /// </summary>
        /// <param name="fileName">The name of the file to be returned</param>
        /// <returns>The file contents</returns>
        public string ReadFile(string fileName)
        {
            if (this.FileNames.ContainsKey(fileName) == false)
            {
                return null;
            }

            FileEntry head = this.Entries[this.FileNames[fileName]];
            var sb = new StringBuilder();
            while (true)
            {
                sb.Append(head.Page);
                if (head.NextPage == FileEntry.EndOfFileChar)
                {
                    break;
                }

                head = this.Entries[head.NextPage.Value];
            }

            return sb.ToString();
        }

        /// <summary>
        /// Releases the resources used by the specified file.
        /// </summary>
        /// <param name="fileName"></param>
        public void DeleteFile(string fileName)
        {
            if (this.FileNames.ContainsKey(fileName) == false)
            {
                return;
            }

            var head = this.Entries[this.FileNames[fileName]];
            do
            {
                head.Busy = false;
                this.dirtyPages.Enqueue(head.Id);
                head = this.Entries[head.NextPage.Value];
            } while (head != null);

            this.FileNames.Remove(fileName);
        }

        /// <summary>
        /// Gets the next entry that is not busy
        /// 
        /// This works by linearly scanning the disk forward until we reach the end.
        /// If that does not work then we'll start back at the beginning and loop again.
        /// </summary>
        /// <returns></returns>
        private FileEntry GetNextFreeEntry()
        {
            // Check if we have any dirty pages that are ready for use...
            if (this.dirtyPages.Count > 0)
            {
                return this.Entries[this.dirtyPages.Dequeue()];
            }

            // Otherwise walk forward until one is found, or hit end of disk...
            for (var ix = nextFreePage; ix < this.Entries.Length; ix++)
            {
                if (this.Entries[ix].Busy == false)
                {
                    nextFreePage = ix + 1;
                    return this.Entries[ix];
                }
            }

            // Start at beginning of the disk and walk forward until our starting location...
            for (var ix = 0; ix < nextFreePage; ix++)
            {
                if (this.Entries[ix].Busy == false)
                {
                    nextFreePage = ix + 1;
                    return this.Entries[ix];
                }
            }

            // We are out of diskspace.
            return null;
        }

        private IEnumerable<string> GetPages(string contents)
        {
            using (var sr = new StringReader(contents))
            {
                var buffer = new char[this.PageSize];
                int offset = 0;
                while (true)
                {
                    var read_count = sr.ReadBlock(buffer, index: 0, count: buffer.Length);
                    offset += read_count;

                    yield return new string(buffer);

                    // check if this is the last page
                    if (offset >= contents.Length)
                    {
                        break;
                    }
                }
            }
        }
    }
}
