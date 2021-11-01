using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace VehiclesInClass
{
    
    public static class Function1
    {
        public class Brand
        {
            public string BrandName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZIP { get; set; }
            public Brand(string strBrandName, string strAddress, string strCity, string strState, string strZIP)
            {
                BrandName = strBrandName;
                Address = strAddress;
                City = strCity;
                State = strState;
                ZIP = strZIP;
            }
            
        }
        public class Vehicle
        {
            public string Model { get; set; }
            public Int64 Year { get; set; }
            public double MPG { get; set; }
            public Brand Brand { get; set; }
            public Vehicle(string strModel, int intYear, double dblMPG)
            {
                Model = strModel;
                Year = intYear;
                MPG = dblMPG;
                
            }
        }
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
           
            log.LogInformation("C# HTTP trigger function processed a request.");

            string strModel = req.Query["Model"];

            string agVehicle = req.Query["Model"];
            Brand Toyota = new Brand("@BrandName", "@Address", "@City", "@State", "@Zip");
            Brand Ford = new Brand("@BrandName", "@Address", "@City", "@State", "@Zip");
            Brand Audi = new Brand("@BrandName", "@Address", "@City", "@State", "@Zip");

            Vehicle ToyotaOne = new Vehicle("ToyotaOne", 2029, 4);
            Vehicle ToyotaTwo = new Vehicle("ToyotaTwo", 2030, 5);
            Vehicle FordOne = new Vehicle("FordOne", 2020, 43);
            Vehicle FordTwo = new Vehicle("FordTwo", 2023, 345);
            Vehicle AudiOne = new Vehicle("AudiOne", 2045, 22);
            Vehicle AudiTwo = new Vehicle("AudiTwo", 2342, 34);



            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            List<Vehicle> arrVehicle = new List<Vehicle>();
            arrVehicle.Add(ToyotaOne);
            arrVehicle.Add(ToyotaTwo);
            arrVehicle.Add(FordOne);
            arrVehicle.Add(FordTwo);
            arrVehicle.Add(AudiOne);
            arrVehicle.Add(AudiTwo);

            
            
          
                
         


            string responseMessage = string.IsNullOrEmpty()
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
