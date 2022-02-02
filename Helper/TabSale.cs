﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Helper
{
    public partial class TabSale
    {
        public int Id { get; set; }
        public int MusicRecordId { get; set; }
        public int Cost { get; set; }
        public int Bonuses { get; set; }
        public int TotalCost { get; set; }

        public virtual TabMusicRecord MusicRecord { get; set; }
    }
}