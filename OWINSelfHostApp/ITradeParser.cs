using Newtonsoft.Json.Linq;
using TradeRepo.Data.Models;

namespace OWINSelfHostApp
{
    public interface ITradeParser
    {
        Trade Parse(JObject trade);
    }
}
