using System.Collections.Generic;
using System.Linq;

namespace Helper.Models
{
    internal class Model
    {

        MusicContext _context;

        public Model()
        {
            _context = new();
        }

        public List<TabAuthor> GetAllAuthors()
         => _context.TabAuthors.ToList();
        public List<TabMusicRecord> GetAllRecords()
         => _context.TabMusicRecords.ToList();
        public List<TabGenre> GetAllGenre()
        => _context.TabGenres.ToList();
        public List<TabGroup> GetAllGroups()
         => _context.TabGroups.ToList();
        public List<TabPopular> GetAllPopular()
         => _context.TabPopulars.ToList();
        public List<TabUser> GetAllUsers()
         => _context.TabUsers.ToList();
        public List<TabBonuse> GetAllBonuses()
        => _context.TabBonuses.ToList();
        public List<TabSale> GetAllSales()
        => _context.TabSales.ToList();

        public List<TabMusicRecord> GetAvailableForPurchase()
        => _context.TabStorages.Where(s => s.Count > 0).Select(s => s.MusicRecord).ToList();
        public List<TabMusicRecord> GetAllRecordsByGroupName(string name)
        => _context.TabMusicRecords.Where(a => a.Author.Group.Name == name).ToList();

        public void InsertBonuses(int bonuses, int userId)
        {
            var user = _context.TabBonuses.Where(t => t.UserId == userId).FirstOrDefault();
            if (user != null)
            {
                user.Count += bonuses;
                _context.TabBonuses.Update(user);
            }
            else
                _context.TabBonuses.Add(new TabBonuse { Count = bonuses, UserId = userId });
            _context.SaveChanges();

        }

        public void BuyRecord(ref TabSale tabSale)
        {
            _context.TabSales.Add(tabSale); ;
            _context.SaveChanges();

        }


        public void AddRecord(TabMusicRecord musicRecord)
        {
            _context.TabMusicRecords.Add(musicRecord);
            _context.SaveChanges();
        }


    }
}
