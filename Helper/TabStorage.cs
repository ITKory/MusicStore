using System;
using System.Collections.Generic;

#nullable disable

namespace Helper
{
    public partial class TabStorage
    {
        public int Id { get; set; }
        public int MusicRecordId { get; set; }
        public int Count { get; set; }

        public virtual TabMusicRecord MusicRecord { get; set; }
    }
}
