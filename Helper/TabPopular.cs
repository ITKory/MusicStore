using System;
using System.Collections.Generic;

#nullable disable

namespace Helper
{
    public partial class TabPopular
    {
        public int Id { get; set; }
        public int MusicRecordId { get; set; }
        public DateTime Date { get; set; }

        public virtual TabMusicRecord MusicRecord { get; set; }
    }
}
