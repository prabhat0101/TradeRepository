using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Text;
using TradeLoader.API.Models;
using System.Collections.Generic;
using System.Linq;
using RestBus.RabbitMQ.Client;
using RestBus.RabbitMQ;
using RestBus.Client;
using TradeRepo.Data.Models;

namespace TradeSaverApi.Tests
{
    [TestClass]
    public class TradeSaverAPITest
    {
        string baseAddress = "http://localhost:9000/";

        [TestMethod]
        public async Task FrontOfficeKPlusTradeSaveTest()
        {
            // Arrange
            var amqpUrlcli = "amqp://localhost:5672"; //AMQP URL for RabbitMQ installation
            var serviceNamecli = "tradeSaver"; //The unique identifier for the target service

            var msgMappercli = new BasicMessageMapper(amqpUrlcli, serviceNamecli);
            using (var client = new RestBusClient(msgMappercli))
            {                
                JObject oJsonObject = new JObject();
                oJsonObject.Add("SourceApplication", "KPlus");
                oJsonObject.Add("Portfolio", "ref123");
                oJsonObject.Add("CounterParty", "abcd");
                oJsonObject.Add("Id", "WAY-111118");
                oJsonObject.Add("Owner", "MUBE");
                oJsonObject.Add("BookingDate", DateTime.Today.ToShortDateString());
                oJsonObject.Add("ValueDate", DateTime.Today.ToShortDateString());
                oJsonObject.Add("MaturityDate", DateTime.Today.ToShortDateString());

                RequestOptions requestOptions = null;

                //Uncomment this section to get a response in JSON format

                requestOptions = new RequestOptions();
                requestOptions.Headers.Add("Accept", "application/json");


                //Send Request                
                var busresponse = client.PostAsync(baseAddress + "api/trades", new StringContent(oJsonObject.ToString(), Encoding.UTF8, "application/json")).Result;

                //Display response
                Assert.AreEqual("OK",busresponse.StatusCode.ToString());
                Console.WriteLine(busresponse.Content.ReadAsStringAsync().Result);

                //Assert Response                    
                var result = busresponse.Content.ReadAsStringAsync().Result;
                Assert.AreEqual(true, result.Contains("WAY"));    
            }

        }

        [TestMethod]
        public async Task FrontOfficeKPlusTradeLoadTest()
        {
            string baseLoadAddress = "http://localhost:8000/";
            var amqpUrlcli = "amqp://localhost:5672"; //AMQP URL for RabbitMQ installation
            var serviceNamecli = "trades"; //The unique identifier for the target service

            var msgMappercli = new BasicMessageMapper(amqpUrlcli, serviceNamecli);
            using (var busClient = new RestBusClient(msgMappercli))
            {   
                JObject oJsonObject = new JObject();
                oJsonObject.Add("source", "KPlus");
                oJsonObject.Add("tradeids", "1234,12345");
                oJsonObject.Add("fields", "ID,Portfolio,CounterParty");    

                RequestOptions requestOptions = null;

                //Uncomment this section to get a response in JSON format

                requestOptions = new RequestOptions();
                requestOptions.Headers.Add("Accept", "application/json");


                //Send Request                
                var busresponse = busClient.PostAsync(baseLoadAddress + "api/tradeloader", new StringContent(oJsonObject.ToString(), Encoding.UTF8, "application/json")).Result;
                
                //Display response
                Console.WriteLine(busresponse.StatusCode);
                Console.WriteLine(busresponse.Content.ReadAsStringAsync().Result);

                //Assert response                    
                var result = busresponse.Content.ReadAsStringAsync().Result;
                TradeLoaderResponse tmp = JsonConvert.DeserializeObject<TradeLoaderResponse>(result);
                Assert.AreEqual(2, tmp.Trades.Count());
                Assert.AreEqual("1234", tmp.Trades.ToList()[0].Id);

            }
        }
    }
}

       
        
    

