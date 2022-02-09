using System.Collections.Generic;

#nullable disable

namespace Helper
{
    public partial class TabGroup
    {
        public TabGroup()
        {
            TabAuthors = new HashSet<TabAuthor>();
            TabMusicRecords = new HashSet<TabMusicRecord>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TabAuthor> TabAuthors { get; set; }
        public virtual ICollection<TabMusicRecord> TabMusicRecords { get; set; }
    }
}
