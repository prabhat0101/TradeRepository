using Newtonsoft.Json.Linq;
using OWINSelfHostApp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TradeRepo.Data;
using TradeRepo.Data.Models;

namespace TradeSaverApi.Controllers
{
    public class TradesController : ApiController
    {
        [HttpPost]        
        public IHttpActionResult PostNewTrade(JObject jtrade)
        {
            log4net.Config.BasicConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
            Trade tradeToSave = null;
            try
            {
                if (jtrade == null)
                {
                    throw new ArgumentNullException();
                }

                dynamic trade = jtrade;
                TradeService tradeService = new TradeService();
                tradeToSave = TradeParserFactory.GetTradeParser(trade.SourceApplication.Value).Parse(jtrade);
                var saved = tradeService.SaveTrade(tradeToSave);
                if (!saved)
                {
                    throw new EntryPointNotFoundException();             
                }
            }
            catch(Exception ex)
            {
                log.Error(ex.ToString());
                return NotFound();
            }
            return Ok(tradeToSave);
        }
    }
}
