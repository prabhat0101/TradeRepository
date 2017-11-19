using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestBus.Client;
using RestBus.RabbitMQ;
using RestBus.RabbitMQ.Client;
using RestBus.RabbitMQ.Subscription;
using RestBus.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TradeLoader.API.Models;
using TradeRepo.Data.Models;

namespace TradeLoader.API
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:8000/";
            //Initialize startup object
            var startup = new Startup();

            // Start OWIN host 
            using (WebApp.Start(url: baseAddress, startup: startup.Configuration))
            {

                Console.WriteLine("Starting web Server...");
                Console.WriteLine("Server running at {0} - press Enter to quit. ", baseAddress);

                //Start RestBus Subscriber/host
                var amqpUrl = "amqp://localhost:5672"; //AMQP URI for RabbitMQ server
                var serviceName = "trades"; //Uniquely identifies this service

                var msgMapper = new BasicMessageMapper(amqpUrl, serviceName);
                var subscriber = new RestBusSubscriber(msgMapper);
                using (var host = new RestBusHost(subscriber, startup.Config))
                {
                    host.Start();
                    Console.ReadLine();
                }               
            }
        }
    }
}

