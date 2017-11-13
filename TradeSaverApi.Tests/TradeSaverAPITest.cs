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
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                JObject oJsonObject = new JObject();
                oJsonObject.Add("SourceApplication", "KPlus");
                oJsonObject.Add("Portfolio", "ref123");
                oJsonObject.Add("CounterParty", "abcd");
                oJsonObject.Add("Id", "WAY-12589");
                oJsonObject.Add("Owner", "MUBE");
                oJsonObject.Add("BookingDate", DateTime.Today.ToShortDateString());
                oJsonObject.Add("ValueDate", DateTime.Today.ToShortDateString());
                oJsonObject.Add("MaturityDate", DateTime.Today.ToShortDateString());

                var response = client.PostAsync(baseAddress + "api/trades", new StringContent(oJsonObject.ToString(), Encoding.UTF8, "application/json")).Result;
                response.EnsureSuccessStatusCode();
                //Console.WriteLine(response);
                var result = response.Content.ReadAsStringAsync().Result;
                // Assert
                Assert.AreEqual("http://localhost:9000/api/trades/WAY-12589", response.Headers.Location.AbsoluteUri);
            }

        }

        [TestMethod]
        public async Task FrontOfficeKPlusTradeLoadTest()
        {
            string baseLoadAddress = "http://localhost:8000/";
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                JObject oJsonObject = new JObject();
                oJsonObject.Add("source", "KPlus");
                oJsonObject.Add("tradeids", "1234,12345");
                oJsonObject.Add("fields", "ID,Portfolio,CounterParty");


                var response = client.PostAsync(baseLoadAddress + "api/tradeloader", new StringContent(oJsonObject.ToString(), Encoding.UTF8, "application/json")).Result;
                response.EnsureSuccessStatusCode();
                var result = response.Content.ReadAsStringAsync().Result;
                TradeLoaderResponse tmp = JsonConvert.DeserializeObject<TradeLoaderResponse>(result);
                Assert.AreEqual(2, tmp.Trades.Count());
                Assert.AreEqual("1234", tmp.Trades.ToList()[0].Id);

            }
        }
    }
}

       
        
    

