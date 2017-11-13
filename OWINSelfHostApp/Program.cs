using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TradeRepo.Data.Models;

namespace OWINSelfHostApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                //using (var client = new HttpClient())
                //{                    
                //    client.DefaultRequestHeaders.Accept.Clear();
                //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //    JObject oJsonObject = new JObject();
                //    oJsonObject.Add("SourceApplication", "KPlus");
                //    oJsonObject.Add("Portfolio", "ref123");
                //    oJsonObject.Add("CounterParty", "abcd");
                //    oJsonObject.Add("Id", "1234");
                //    oJsonObject.Add("Owner", "MUBE");
                //    oJsonObject.Add("BookingDate", DateTime.Today.ToShortDateString());
                //    oJsonObject.Add("ValueDate", DateTime.Today.ToShortDateString());
                //    oJsonObject.Add("MaturityDate", DateTime.Today.ToShortDateString());

                //    var response =  client.PostAsync(baseAddress + "api/trades", new StringContent(oJsonObject.ToString(), Encoding.UTF8, "application/json")).Result;
                //    response.EnsureSuccessStatusCode();                    
                //    Console.WriteLine(response);
                //    Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine("Starting web Server...");                
                Console.WriteLine("Server running at {0} - press Enter to quit. ", baseAddress);
                Console.ReadLine();

                //}
            }
        }
    }
}
