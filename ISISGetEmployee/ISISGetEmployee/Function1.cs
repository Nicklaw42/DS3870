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
using System.Data.SqlClient;



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
            string strConnection = "Server=mySQLServer\\myInstanceName;myDatabase=dbSpies;User Id=myUsername;Password=myPassword;";

            string strCodeName = req.Query["CodeName"];
            string strAgency = req.Query["Agency"];
            log.LogInformation("HTTP trigger on getEmployee proceed a request for " + strCodeName + "");



            Agency ISIS = new Agency("ISIS", "10fiejfioej", "399343");
            Agency CIA = new Agency("CIA", "23302232", "29930040");
            Employee Archer = new Employee("Sterling", "Archer", "Duchess", "Field Agent", "Active", ISIS);
            Employee Lana = new Employee("dog", "Aslad", "BAnana", "Agenter", "Active", ISIS);
            Employee Pam = new Employee("Pam", "Poovy", "Duchess", "Human Resources", "Active", CIA);
           

          
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            Employee[] arrEmployees = new Employee[] { Archer, Lana, Pam };
  
            List<Employee> firstFoundEmployees = new List<Employee>();
            
            foreach (Employee empCurrent in arrEmployees)
            {
                if (strCodeName == empCurrent.CodeName)
                {
                    firstFoundEmployees.Add(empCurrent);
                }
            }
            if(firstFoundEmployees.Count > 0)
            {
                return new OkObjectResult(firstFoundEmployees);
            }else
            {
                return new OkObjectResult("Employee Not Found");
            }
        }
    }
}
