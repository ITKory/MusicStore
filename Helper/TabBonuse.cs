#nullable disable

namespace Helper
{
    public partial class TabBonuse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Count { get; set; }

        public virtual TabUser User { get; set; }
    }
}
