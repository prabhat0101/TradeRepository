using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeRepo.Data.Models
{
    public class Trade
    {
        public string Id { get; set; }
        public string SourceApplication { get; set; }
        public string Portfolio { get; set; }
        public string CounterParty { get; set; }
        public string Trader { get; set; }
        public string TradeDate { get; set; }
        public string ValueDate { get; set; }
        public string MaturityDate { get; set; }
    }
}
