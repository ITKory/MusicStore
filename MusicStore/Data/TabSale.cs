#nullable disable

namespace MusicStore.Data
{
    public partial class TabSale
    {
        public int Id { get; set; }
        public int MusicRecordId { get; set; }
        public int Cost { get; set; }
        public int Bonuses { get; set; }
        public int TotalCost { get; set; }
        public int UserId { get; set; }
        public int Count { get; set; }

        public virtual TabMusicRecord MusicRecord { get; set; }
        public virtual TabUser User { get; set; }
    }
}
