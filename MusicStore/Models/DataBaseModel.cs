using MusicStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicStore.Models
{
    internal class DataBaseModel
    {

        MusicContext _context;

        public DataBaseModel()
        {
            _context = new();
        }

        public List<TabAuthor> AuthorInfo()
         => _context.TabAuthors.ToList();
        public List<TabMusicRecord> RecordInfo()
         => _context.TabMusicRecords.ToList();
        public List<TabGroup> GroupInfo()
         => _context.TabGroups.ToList();
        public List<TabGenre> GenreInfo()
        => _context.TabGenres.ToList();
        public List<TabPopular> PopularInfo()
         => _context.TabPopulars.ToList();
        public List<TabPublisher> PublisherInfo()
          => _context.TabPublishers.ToList();
        public List<TabUser> UserInfo()
         => _context.TabUsers.ToList();
        public List<TabBonuse> BonuseInfo()
        => _context.TabBonuses.ToList();
        public List<TabStorage> StorageInfo()
        => _context.TabStorages.ToList();
        public List<TabSale> SaleInfo()
        => _context.TabSales.ToList();
        public List<TabPurchaseHistory> GetBasket(int UID)
            => _context.TabPurchaseHistories.Where(h => h.UserId == UID).ToList();
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
        public List<TabMusicRecord> GetAllNewRecords()
        {


            var buff = RecordInfo()
                     .Where(r => r.PublishDate.Year >= DateTime.Today.Year
                                           && r.PublishDate.Month >= DateTime.Today.Month - 2).Select(r => r).ToList();

            return buff;


        }

        public List<TabMusicRecord> SerchRecords(string genre, string publisher, string sortBy, string searchVal)
        {
            var records = _context.TabMusicRecords.ToList();
            if (searchVal != null)
                records = _context.TabMusicRecords
                    .Where(r =>
                    r.Author.Person.LastName == searchVal ||
                    r.Author.Person.FirstName == searchVal ||
                    r.Group.Name == searchVal
                    ).Select(r => r).ToList();
            if (genre != null)
                records = records.Where(r => r.Genre.Name == genre).Select(r => r).ToList();

            if (publisher != null)
                records = records.Where(r => r.Publisher.Name == publisher).Select(r => r).ToList();

            //    records = records.OrderByDescending(r=>r.PublishDate).Select(r=>r).ToList();
            return records.ToList();

        }

        public void AddRecord(TabMusicRecord musicRecord)
        {
            _context.TabMusicRecords.Add(musicRecord);
            _context.SaveChanges();
        }

        

        public void UpdateCountInBasket( TabPurchaseHistory basket, int recordId, int insertCount)
        {
            var changebleBasket = _context.TabPurchaseHistories.Where(h => h.Id == basket.Id).FirstOrDefault();
            int storageCount = _context.TabStorages.Where(r => r.MusicRecordId == recordId).Select(r => r.Count).FirstOrDefault();
            if (changebleBasket != null)
            {
                if (insertCount > 0 && storageCount > changebleBasket.RecordsCount)
                {
                    changebleBasket.RecordsCount += insertCount;
                    _context.TabPurchaseHistories.Update(changebleBasket);
                }
                if (insertCount <0 && changebleBasket.RecordsCount > 1)
                {
                    changebleBasket.RecordsCount += insertCount;
                    _context.TabPurchaseHistories.Update(changebleBasket);
                  
                }
                _context.SaveChanges();
                   

            }
         
        }
    }
}
