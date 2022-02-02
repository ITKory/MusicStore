using System;
using System.Collections.Generic;

#nullable disable

namespace Helper
{
    public partial class TabGenre
    {
        public TabGenre()
        {
            TabMusicRecords = new HashSet<TabMusicRecord>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TabMusicRecord> TabMusicRecords { get; set; }
    }
}
