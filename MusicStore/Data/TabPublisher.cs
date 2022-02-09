using System.Collections.Generic;

#nullable disable

namespace MusicStore.Data
{
    public partial class TabPublisher
    {
        public TabPublisher()
        {
            TabMusicRecords = new HashSet<TabMusicRecord>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TabMusicRecord> TabMusicRecords { get; set; }
    }
}
