using System;
using System.Collections.Generic;

#nullable disable

namespace MusicStore.Data
{
    public partial class TabUser
    {
        public TabUser()
        {
            TabBonuses = new HashSet<TabBonuse>();
            TabPurchaseHistories = new HashSet<TabPurchaseHistory>();
            TabSales = new HashSet<TabSale>();
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Pwd { get; set; }

        public virtual TabPerson Person { get; set; }
        public virtual ICollection<TabBonuse> TabBonuses { get; set; }
        public virtual ICollection<TabPurchaseHistory> TabPurchaseHistories { get; set; }
        public virtual ICollection<TabSale> TabSales { get; set; }
    }
}
