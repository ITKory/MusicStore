using System;
using System.Collections.Generic;

#nullable disable

namespace Helper
{
    public partial class TabPurchaseHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MusicRecordId { get; set; }
        public int RecordsCount { get; set; }

        public virtual TabMusicRecord MusicRecord { get; set; }
        public virtual TabUser User { get; set; }
    }
}
