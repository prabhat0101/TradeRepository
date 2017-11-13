using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeRepo.Data.Plugins;

namespace TradeRepo.Data
{
    public class TradeServicePluginFactory
    {
        public static ITradeServicePlugin Get(string sourceApplication)
        {
            ITradeServicePlugin plugin = null;
            switch (sourceApplication)
            {
                case "KPlus":
                    plugin = new SQLLiteTradeServicePlugin();
                    break;
                case "Xone":
                   // could be extended on demand
                    break;
            }
            return plugin;
        }
    }
}
