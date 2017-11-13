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
using TradeLoader.API.Models;
using TradeRepo.Data.Models;

namespace TradeLoader.API
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:8000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("Starting web Server...");
                Console.WriteLine("Server running at {0} - press Enter to quit. ", baseAddress);
                Console.ReadLine();
            }
        }
    }
}

