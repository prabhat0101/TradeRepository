using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.ModelBinding.Binders;
using TradeSaverApi.ModelBinders;
using TradeRepo.Data.Models;

namespace OWINSelfHostApp
{
    public class Startup
    {
        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            var provider = new SimpleModelBinderProvider(
            typeof(Trade), new TradeModelBinder());
            config.Services.Insert(typeof(ModelBinderProvider), 0, provider);

            appBuilder.UseWebApi(config);
        }
    }
}
