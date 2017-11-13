using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TradeLoader.API.Models;
using TradeRepo.Data;
using TradeRepo.Data.Models;

namespace TradeLoader.API.Controllers
{
    public class TradeLoaderController: ApiController
    {       

        [HttpPost]
        [ResponseType(typeof(TradeLoaderResponse))]
        public IHttpActionResult FetchTradeViews(FilterCriteria filterCriteria)
        {
            log4net.Config.BasicConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));

            IEnumerable<Trade> trades;
            try
            {
                if (filterCriteria == null)
                    throw new ArgumentNullException();

                TradeService tradeService = new TradeService();
                var tradeIds = filterCriteria.TradeIds.Split(',').ToList();
                var fields = filterCriteria.Fields.Split(',').ToList();
                trades = tradeService.LoadTrade(tradeIds, fields, filterCriteria.Source);                
            }
            catch(ArgumentException exception)
            {
                //Logging the exception using Log4Net for monitoring purpose.
                log.Error(exception.ToString());
                return NotFound();
            }
            return Ok(new TradeLoaderResponse(trades));
        }
    }
}
