using System;

namespace Fat32Algo
{
    /// <summary>
    /// Represents an entry within the <see cref="FatTable"/>.
    /// </summary>
    partial class FileEntry
    {
        /// <summary>
        /// Gets the special character for end of file
        /// </summary>
        public static int EndOfFileChar { get; } = -1;

        /// <summary>
        /// Gets  the index of this entry.
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Gets the memory block that is up to <see cref="FatTable.PageSize"/>.
        /// </summary>
        public Memory<byte> Page { get; set; }

        /// <summary>
        /// Gets or sets the index of the next <see cref="FatTable.Entries"/> that continues this file.
        /// </summary>
        public int? NextPage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating wheather this entry is in use.
        /// </summary>
        public bool Busy { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileEntry"/> class.
        /// </summary>
        /// <param name="entryId">The index of this entry</param>
        public FileEntry(int entryId)
        {
            this.Id = entryId;
        }

        /// <summary>
        /// Gets a debug textual representation of this entry.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"[{(this.Busy? "InUse" : "Free")}] {this.Id} -> {this.NextPage}";
        }
    }
}
