using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace getDogs
{
    public class Dog
    {
        public string Breed { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public Dog(string strBreed, string strName, string strOwner)
        {
            Breed = strBreed;
            Name = strName;
            Owner = strOwner;
        }
    }

    public class Vet
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int64 Wage { get; set; }
        public Dog Dog { get; set; }
        public Vet(string strID, string strFirstName, string strLastName, Int64 intWage, Dog agDog)
        {
            ID = strID;
            FirstName = strFirstName;
            LastName = strLastName;
            Wage = intWage;
            Dog = agDog;
        }
    }
    public static class Function1
    {
        [FunctionName("getDog")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function found a dog.");

            

            Dog Boomer = new Dog("Beagle", "Boomer", "Allen");
            Dog Sam = new Dog("Ridgeback", "Sam", "Law");
            Dog Rosy = new Dog("Terrier", "Rosy", "Barns");

            List<Dog> arrDogs = new List<Dog>();
            arrDogs.Add(Sam);
            arrDogs.Add(Rosy);
            arrDogs.Add(Boomer);

            List<Dog> arrFoundDog = new List<Dog>();

            foreach (Dog dog in arrDogs)
            {
                if (dog == Sam)
                {
                    arrFoundDog.Add(dog);
                }
                else
                {
                    return new OkObjectResult("There is no dog here");
                }
            }
            return new OkObjectResult(arrFoundDog);



           
            
        }
    }
}
