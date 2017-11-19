using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeRepo.Data.Models;

namespace TradeLoader.API.Models
{
    public class TradeLoaderResponse
    {

        [JsonProperty("trades")]
        public IEnumerable<Trade> Trades { get; set; }

        public TradeLoaderResponse(IEnumerable<Trade> trades)
        {
            Trades = trades;
        }
    }
}
