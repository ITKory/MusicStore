using System.Collections.Generic;

#nullable disable

namespace MusicStore.Data
{
    public partial class TabAuthor
    {
        public TabAuthor()
        {
            TabMusicRecords = new HashSet<TabMusicRecord>();
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public int GroupId { get; set; }

        public virtual TabGroup Group { get; set; }
        public virtual TabPerson Person { get; set; }
        public virtual ICollection<TabMusicRecord> TabMusicRecords { get; set; }
    }
}
