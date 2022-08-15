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

            string Order = req.Query["Order"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //var data = (JObject)JsonConvert.DeserializeObject(requestBody);
            var list = JsonConvert.DeserializeObject<SortModel>(requestBody);
            
            Order = Order ?? "asc";
            
            var a = list.Number;

            if (Order.ToUpper() == "ASC") { Array.Sort(a); }
            else if (Order.ToUpper() == "DESC") { Array.Sort(a);
                Array.Reverse(a);
            }
            else { return new BadRequestObjectResult("Order Can only be Asc or Desc"); }

            
           


            //JArray sorted = new JArray(name.OrderBy(obj => obj));
            ///var n = name.number1;
            //string responseMessage = $"Hello, {a}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(a);
        }
    }
}
