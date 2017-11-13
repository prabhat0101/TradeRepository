using Newtonsoft.Json.Linq;
using OWINSelfHostApp;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TradeRepo.Data;
using TradeRepo.Data.Models;

namespace TradeSaverApi.Controllers
{
    public class TradesController : ApiController
    {
        
        public HttpResponseMessage PostNewTrade(JObject jtrade)
        {            
            dynamic trade = jtrade;            
            TradeService tradeService = new TradeService();
            Trade tradeToSave = TradeParserFactory.GetTradeParser(trade.SourceApplication.Value).Parse(jtrade);
            tradeService.SaveTrade(tradeToSave);
            var response = Request.CreateResponse<Trade>(HttpStatusCode.Created, tradeToSave);
            string uri = Url.Link("DefaultApi", new { id = tradeToSave.Id });
            response.Headers.Location = new Uri(uri);
            return response;
            
        }
    }
}
