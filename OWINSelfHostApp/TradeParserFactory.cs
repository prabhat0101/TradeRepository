using OWINSelfHostApp.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWINSelfHostApp
{
    public class TradeParserFactory
    {
        public static ITradeParser GetTradeParser(string SourceApp)
        {
            ITradeParser tradeParser = null;
            switch (SourceApp) {
                case "KPlus":
                    tradeParser = new KPlusParser();
                    break;
                case "Xone":
                    tradeParser = new XoneParser();
                    break;
            }
            return tradeParser;            
        }
    }
}
