using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace TradeLoader.API.Models
{
    [DataContract]
    public class FilterCriteria
    {
        [DataMember]
        [JsonProperty("tradeids")]
        public string TradeIds { get; set; }

        [DataMember]
        [JsonProperty("fields")]
        public string Fields { get; set; }

        [DataMember]
        [JsonProperty("source")]
        public string Source { get; set; }

    }
}
