using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeRepo.Data.Models;

namespace TradeRepo.Data
{
    public interface ITradeServicePlugin
    {
        string connectionString { get; set; }
        bool Save(Trade trade);
        IEnumerable<Trade> Load(List<string> ids, List<string> fields);
        bool Delete(IEnumerable<string> Ids);
    }
}
