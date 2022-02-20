using MusicStore.Data;
using MusicStore.Infrastructure.Constants;
using MusicStore.Infrastructure.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MusicStore.Models
{
    internal class DataBaseModel
    {
        private MusicContext _context;

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

        public List<TabAdmin> AdminInfo()
        => _context.TabAdmins.ToList();

        public List<TabStorage> StorageInfo()
        => _context.TabStorages.ToList();

        public List<TabSale> SaleInfo()
        => _context.TabSales.ToList();

        public List<TabUser> UserssInfo()
         => _context.TabUsers.ToList();

        public List<TabPurchaseHistory> GetBasket(int userId)
            => _context.TabPurchaseHistories.Where(h => h.UserId == userId).ToList();

        public List<TabMusicRecord> GetAvailableForPurchase()
        => _context.TabStorages.Where(s => s.Count > 0).Select(s => s.MusicRecord).ToList();

        public List<TabMusicRecord> GetAllRecordsByGroupName(string name)
        => _context.TabMusicRecords.Where(a => a.Author.Group.Name == name).ToList();

        public List<TabSale> GetHistory(int userId)
      => _context.TabSales.Where(s => s.UserId == userId).ToList();

        public List<TabMusicRecord> GetAllPopular()
        {
            return _context.TabPopulars.Select(r => r.MusicRecord).ToList();
        }

        public List<TabMusicRecord> GetAllNewRecords()
        {
            var buff = RecordInfo().Where(r => r.PublishDate.Year >= DateTime.Today.Year
                                             && r.PublishDate.Month >= DateTime.Today.Month - 2).ToList();

            return buff;
        }

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

        public List<TabMusicRecord> SerchRecords(string genre, string publisher, string searchVal)
        {
            Regex regex = new(@$"{searchVal.ToLower()}(\w*)");
            var buff = _context.TabMusicRecords.Select(r => r.Name).ToList();
            string combinedString = string.Join(",", buff.Select(el => el.ToLower()));
            var records = _context.TabMusicRecords.ToList();

            MatchCollection matches = regex.Matches(combinedString);

            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    records = records.Where(r => regex.Match(r.Name.ToLower()).ToString() == match.ToString()).Select(r => r).ToList();
            }

            if (genre != null)
                records = records.Where(r => r.Genre.Name == genre).Select(r => r).ToList();

            if (publisher != null)
                records = records.Where(r => r.Publisher.Name == publisher).Select(r => r).ToList();

            return records.ToList();
        }

        public void AddRecord(TabMusicRecord musicRecord)
        {
            _context.TabMusicRecords.Add(musicRecord);
            _context.SaveChanges();
        }

        public void ClearBasket(int userId)
        {
            var basketItems = _context.TabPurchaseHistories.Where(r => r.UserId == userId);
            foreach (var item in basketItems)
                _context.TabPurchaseHistories.Remove(item);
            _context.SaveChanges();
        }

        public bool CanUserLogin(string password, string login)
        {
            var user = _context.TabUsers.Where(u => u.Pwd == password && u.Login == login).FirstOrDefault();

            if (user is not null)
            {
                UserConstant.UserId = user.Id;
                return true;
            }
            var userIsAdmin = _context.TabAdmins.Where(u => u.Pwd == password && u.Login == login).FirstOrDefault();
            if (userIsAdmin is not null)
            {
                UserConstant.UserId = userIsAdmin.Id;
                UserConstant.UserIsAdmin = true;
                return true;
            }
            return false;
        }

        public void BuyAll(List<TabPurchaseHistory> baskets)
        {
            foreach (var basket in baskets)
                new DataBaseFacade(_context).BuyRecord(basket.MusicRecord.Cost, basket.MusicRecordId, basket.UserId);
        }

        public void IncrementRecordsCount(List<TabPurchaseHistory> baskets, int recordId)
        {
            var basket = baskets.Where(r => r.MusicRecordId == recordId).FirstOrDefault();
            if (basket != null)
                new DataBaseFacade(_context).UpdateCountInBasket(basket, recordId, 1);
        }

        public void DecrementRecordsCount(List<TabPurchaseHistory> baskets, int recordId)
        {
            var basket = baskets.Where(r => r.MusicRecordId == recordId).FirstOrDefault();
            if (basket != null)
                new DataBaseFacade(_context).UpdateCountInBasket(basket, recordId, -1);
        }
    }
}