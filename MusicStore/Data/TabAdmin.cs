﻿#nullable disable

namespace MusicStore.Data
{
    public partial class TabAdmin
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Pwd { get; set; }

        public virtual TabPerson Person { get; set; }
    }
}
