using Newtonsoft.Json.Linq;
using TradeRepo.Data.Models;

namespace OWINSelfHostApp.Parsers
{
    public class KPlusParser : ITradeParser
    {
        public Trade Parse(JObject jtrade)
        {
            Trade trade = new Trade();
            dynamic dtrade = jtrade;
            trade.SourceApplication = dtrade.SourceApplication.Value;
            trade.CounterParty = dtrade.CounterParty.Value;
            trade.Id = dtrade.Id.Value;
            trade.Portfolio = dtrade.Portfolio.Value;
            trade.Trader = dtrade.Owner.Value;
            trade.TradeDate = dtrade.BookingDate.Value;
            trade.ValueDate = dtrade.ValueDate.Value;
            trade.MaturityDate = dtrade.MaturityDate.Value;
            return trade;
        }
    }
}
