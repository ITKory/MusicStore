using System;
using System.Collections.Generic;

#nullable disable

namespace Helper
{
    public partial class TabCountry
    {
        public TabCountry()
        {
            TabPeople = new HashSet<TabPerson>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TabPerson> TabPeople { get; set; }
    }
}
