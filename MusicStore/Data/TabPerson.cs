using System.Collections.Generic;

#nullable disable

namespace MusicStore.Data
{
    public partial class TabPerson
    {
        public TabPerson()
        {
            TabAdmins = new HashSet<TabAdmin>();
            TabAuthors = new HashSet<TabAuthor>();
            TabUsers = new HashSet<TabUser>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }

        public virtual TabCountry Country { get; set; }
        public virtual ICollection<TabAdmin> TabAdmins { get; set; }
        public virtual ICollection<TabAuthor> TabAuthors { get; set; }
        public virtual ICollection<TabUser> TabUsers { get; set; }
    }
}
