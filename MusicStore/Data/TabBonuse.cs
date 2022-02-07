using System;
using System.Collections.Generic;

#nullable disable

namespace MusicStore.Data
{
    public partial class TabBonuse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Count { get; set; }

        public virtual TabUser User { get; set; }
    }
}
