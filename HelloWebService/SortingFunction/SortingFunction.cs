using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace SortFunctions
{
    public static class SortingFunction
    {
        [FunctionName("SortingFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string order = req.Query["order"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<JToken>(requestBody);
            

            order = order ?? "asc";


            var sortedList = data.OrderBy(x => x.SelectToken("BaseData1")).ToList(); ///SelectToken("BaseData1")).ToList();


            string responseMessage =  $"Hello,  This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
