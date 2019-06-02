using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Fat32Algo
{
    partial class FatTable
    {
        public FileEntry[] Entries { get; }

        public int PageSize { get; }

        public Dictionary<string, int> FileNames { get; }

        public FatTable(int maxBlocks, int pageSize)
        {
            this.Entries = new FileEntry[maxBlocks];
            this.FileNames = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            this.PageSize = pageSize;
        }

        public void WriteFile(string fileName, string contents)
        {
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

        public string ReadFile(string fileName)
        {
            if (this.FileNames.ContainsKey(fileName) == false)
            {
                return null;
            }

            FileEntry head = this.Entries[this.FileNames[fileName]];
            var sb = new StringBuilder();
            while(true)
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

        private FileEntry GetNextFreeEntry()
        {
            return this.Entries.FirstOrDefault(e => e.Busy == false);
        }

        private IEnumerable<string> GetPages(string contents)
        {
            using (var sr = new StringReader(contents))
            {
                var buffer = new char[this.PageSize];
                int offset = 0;
                while (true)
                {
                    var read_count = sr.ReadBlock(buffer, offset, this.PageSize);
                    offset += read_count;

                    yield return new string(buffer);

                    // check if this is the last page
                    if (read_count < this.PageSize)
                    {
                        break;
                    }
                }
            }
        }
    }
}
