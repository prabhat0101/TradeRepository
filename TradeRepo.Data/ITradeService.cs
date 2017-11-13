using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeRepo.Data.Models;

namespace TradeRepo.Data
{
    public interface ITradeService
    {
        bool SaveTrade(Trade trade);
        IEnumerable<Trade> LoadTrade(List<string> Ids, List<string> Fields, string sourceApplication);
    }
}
