using System;
using System.Collections.Generic;

#nullable disable

namespace Helper
{
    public partial class TabMusicRecord 
    {
        public TabMusicRecord()
        {
            TabPopulars = new HashSet<TabPopular>();
            TabPurchaseHistories = new HashSet<TabPurchaseHistory>();
            TabSales = new HashSet<TabSale>();
            TabStorages = new HashSet<TabStorage>();
        }

        public int Id { get; set; }
        public int GenreId { get; set; }
        public int GroupId { get; set; }
        public int PublisherId { get; set; }
        public int AuthorId { get; set; }
        public int TrackCount { get; set; }
        public DateTime PublishDate { get; set; }
        public int ProductionCoasts { get; set; }
        public int Cost { get; set; }
        public string Name { get; set; }
        public bool Visible { get; set; }

        public virtual TabAuthor Author { get; set; }
        public virtual TabGenre Genre { get; set; }
        public virtual TabGroup Group { get; set; }
        public virtual TabPublisher Publisher { get; set; }
        public virtual ICollection<TabPopular> TabPopulars { get; set; }
        public virtual ICollection<TabPurchaseHistory> TabPurchaseHistories { get; set; }
        public virtual ICollection<TabSale> TabSales { get; set; }
        public virtual ICollection<TabStorage> TabStorages { get; set; }
    }
}
