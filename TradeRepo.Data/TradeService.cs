using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeRepo.Data.Models;
using TradeRepo.Data.Plugins;

namespace TradeRepo.Data
{
    public class TradeService : ITradeService
    {
        public IEnumerable<Trade> LoadTrade(List<string> Ids, List<string> Fields, string sourceApplication)
        {
            return TradeServicePluginFactory.Get(sourceApplication).Load(Ids, Fields);
        }

        public bool SaveTrade(Trade trade)
        {            
            return TradeServicePluginFactory.Get(trade.SourceApplication).Save(trade);
        }
    }
}
