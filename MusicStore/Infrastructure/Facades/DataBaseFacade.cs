﻿using MusicStore.Data;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.Infrastructure.Facades
{
    internal class DataBaseFacade:DataBaseModel
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
        public List<TabMusicRecord> GetAllPopular()
        {
            return _dbContext.PopularInfo().Select(r => r.MusicRecord).ToList();
        }

    }
}