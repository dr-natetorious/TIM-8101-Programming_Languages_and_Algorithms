﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fat32Algo
{
    partial class FileEntry
    {
        public static int EndOfFileChar { get; } = -1;

        public int Id { get; }

        public string Page { get; set; }
        public int? NextPage { get; set; }
        public bool Busy { get; set; }

        public FileEntry(int entryId)
        {
            this.Id = entryId;
        }
    }
}
