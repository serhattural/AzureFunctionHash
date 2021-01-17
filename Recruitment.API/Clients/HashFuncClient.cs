using Microsoft.Extensions.Logging;
using Recruitment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Recruitment.API.Clients
{
    public class HashFuncClient : BaseFuncClient, IHashFuncClient
    {
        private readonly HttpClient client;
        private readonly FunctionConfig functionConfig;
        private readonly ILogger<HashFuncClient> logger;

        public HashFuncClient(HttpClient client, FunctionConfig functionConfig, ILogger<HashFuncClient> logger)
        {
            this.client = client;
            this.functionConfig = functionConfig;
            this.logger = logger;
        }
        public async Task<string> GetHash(string key)
        {
            string url = functionConfig.MapOption[nameof(HashFuncClient)].Url;
            string requestUri = $"{url}/{key}";
            var response = await client.GetAsync(requestUri);
            if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            logger.LogError($"Something went wrong when calling {requestUri}");
            return string.Empty;
        }
    }
}
