using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Infrastructure.Constants;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace MusicStore.Infrastructure.Facades
{
    internal class DataBaseFacade:DataBaseModel
    {

       
        MusicContext _context;
 
        public DataBaseFacade(MusicContext context)
        {
           
            _context = context;
        }

 

        public void BuyRecord(int cost, int recordId, int userId, int bonuses = 0, bool useB = true)
        {

            var totalCost = cost;
            var discont = cost * 50 / 100;
            if (useB && bonuses > discont)
            {
                totalCost -= discont;
                InsertBonuses(-discont, userId);
            }
            else
            {
                discont = 0;
                InsertBonuses(cost * 10 / 100, userId);
            }

            var record = new TabSale
            {
                MusicRecordId = recordId,
                UserId = userId,
                Bonuses = discont,
                Cost = cost,
                TotalCost = totalCost,
            };
            BuyRecord(ref record);
        }

   

         
        public async void UpdateCountInBasket(TabPurchaseHistory basket, int recordId, int insertCount)
        {
             var changebleBasket = await _context.TabPurchaseHistories.Where(h => h.Id == basket.Id).FirstOrDefaultAsync();
             int storageCount = await _context.TabStorages.Where(r => r.MusicRecordId == recordId).Select(r => r.Count).FirstOrDefaultAsync();
            if (changebleBasket != null)
            {
                if (insertCount > 0 && storageCount > changebleBasket.RecordsCount)
                {
                    changebleBasket.RecordsCount += insertCount;
                    _context.TabPurchaseHistories.Update(changebleBasket);
                }
                if (insertCount < 0 && changebleBasket.RecordsCount > 1)
                {
                    changebleBasket.RecordsCount += insertCount;
                    _context.TabPurchaseHistories.Update(changebleBasket);

                }
                _context.SaveChanges();


            }

        }

       


      
    }
}
