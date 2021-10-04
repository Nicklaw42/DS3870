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



namespace ISISGetEmployee
{
  
  
    public static class Function1
    {
        private class Agency
        {
            public string Name { get; set; }
            public string Address { get; set; }
            public string Phone { get; set; }



            public Agency(string strName, string strAddress, string strPhone)
            {
                Name = strName;
                Address = strAddress; 
                Phone = strPhone;

            }
        }
        private class Employee
        {
            public string FirstName { get; set; }

            public string LastName { get; set; }
            public string CodeName { get; set; }

            public string Position { get; set; }

            public string Status { get; set; }

            public Agency Agency { get; set;}
            public Employee(string strFirstName, string strLastName, string strCodeName, string strPosition, string strStatus, Agency agSpyAgency)
            {
                FirstName = strFirstName;
                LastName = strLastName;
                CodeName = strCodeName;
                Position = strPosition;
                Status = strStatus;
                Agency = agSpyAgency;
            }


        }
        [FunctionName("getEmployee")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string strCodeName = req.Query["CodeName"];

            Agency ISIS = new Agency("ISIS", "10fiejfioej", "399343");
            Employee Archer = new Employee("Sterling", "Archer", "Duchess", "Field Agent", "Active", ISIS);
            Employee Lana = new Employee("dog", "Aslad", "BAnana", "Agenter", "Active", ISIS);
           

          
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            List < Employee > 1stFoundEmployess = new List<Employee>();
            arrEmployees.Add(Archer);
            arrEmployees.Add(Lana);
           foreach(Employee emp Current in arrEmployees)
            {
                if(strCodeName == empCurrent.CodeName in arrEmployees)
                {
                    1stFoundEmployees.Add(Current);
                }
            } else
            {
                if(strCodeName == "Duchess")
                {
                    return new OkObjectResult(Archer);
                }
            }
            return new OkObjectResult("Employee Not Found");


        }
    }
}
