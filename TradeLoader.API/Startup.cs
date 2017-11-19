using Owin;
using RestBus.RabbitMQ;
using RestBus.RabbitMQ.Subscription;
using RestBus.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ModelBinding.Binders;

namespace TradeLoader.API
{
    public class Startup
    {
        HttpConfiguration config = new HttpConfiguration();

        public HttpConfiguration Config
        {
            get { return config; }
        }

        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }
}

