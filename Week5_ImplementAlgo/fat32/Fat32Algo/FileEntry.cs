using System;
using System.Collections.Generic;
using System.Text;

namespace Fat32Algo
{
    partial class FileEntry
    {
        public static int EndOfFileChar { get; } = -1;

        public int Id { get; }

        public Memory<byte> Page { get; set; }
        public int? NextPage { get; set; }
        public bool Busy { get; set; }

        public FileEntry(int entryId)
        {
            this.Id = entryId;
        }

        public override string ToString()
        {
            return $"[{(this.Busy? "InUse" : "Free")}] {this.Id} -> {this.NextPage}";
        }
    }
}
