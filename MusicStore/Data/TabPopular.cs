using System;

#nullable disable

namespace MusicStore.Data
{
    public partial class TabPopular
    {
        public int Id { get; set; }
        public int MusicRecordId { get; set; }
        public DateTime Date { get; set; }

        public virtual TabMusicRecord MusicRecord { get; set; }
    }
}
