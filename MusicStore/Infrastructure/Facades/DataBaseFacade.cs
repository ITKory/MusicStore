using MusicStore.Data;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MusicStore.Infrastructure.Facades
{
    internal class DataBaseFacade : DataBaseModel , IDisposable
    {

        DataBaseModel _dbContext;
        public DataBaseFacade()
        {
            _dbContext = new();
        }

        public void BuyRecord(int cost, int recordId, int userId, int bonuses = 0, bool useB = true)
        {

            var totalCost = cost;
            var discont = cost * 50 / 100;
            if (useB && bonuses > discont)
            {
                totalCost -= discont;
                _dbContext.InsertBonuses(-discont, userId);
            }
            else
            {
                discont = 0;
                _dbContext.InsertBonuses(cost * 10 / 100, userId);
            }

            var record = new TabSale
            {
                MusicRecordId = recordId,
                UserId = userId,
                Bonuses = discont,
                Cost = cost,
                TotalCost = totalCost,
            };
            _dbContext.BuyRecord(ref record);
        }

        public void IncrementRecordsCount(  ObservableCollection<TabPurchaseHistory> baskets, int recordId)
        {
            var basket = baskets.Where(r => r.MusicRecordId == recordId).FirstOrDefault();
            if (basket != null)
                _dbContext.UpdateCountInBasket(  basket, recordId, 1);
        }

        public void DecrementRecordsCount(ObservableCollection<TabPurchaseHistory> baskets, int recordId)
        {
           var  basket = baskets.Where(r => r.MusicRecordId == recordId).FirstOrDefault();
            if (basket != null)
            _dbContext.UpdateCountInBasket(  basket, recordId, -1);
        }

        public List<TabMusicRecord> GetAllPopular()
        {
            return _dbContext.PopularInfo().Select(r => r.MusicRecord).ToList();
        }
        public void BuyAll(ObservableCollection<TabPurchaseHistory> baskets)
        {
            foreach (var basket in baskets)
                BuyRecord(basket.MusicRecord.Cost, basket.MusicRecordId, basket.UserId);
            //дописать покупку товаров 
            //очистить корзину 
            // объеденить фасад и модель или еще раз хорошенько все распределить 
            //ревью кода, почистить все чтобы было не стыдно

        }
        public void Dispose()
        {
            GC.Collect();
        }
    }
}
