using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Recruitment.Functions
{
    public static class HashFunction
    {
        [FunctionName("HashFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "HashFunction/{key}")] HttpRequest req,
            string key,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (string.IsNullOrWhiteSpace(key))
                return new BadRequestObjectResult("Hash key cannot be null or empty. Please use as baseURL/hash/{key}");

            string str = key;
            ICrypto crypto = new MD5Crypto();
            string responseMessage = crypto.Encrypt(str);

            return new OkObjectResult(responseMessage);
        }
    }
}
