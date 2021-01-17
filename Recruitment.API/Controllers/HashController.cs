using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Recruitment.API.Clients;
using Recruitment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Recruitment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashController : ControllerBase
    {
        private readonly IHashFuncClient client;
        private readonly ILogger<HashController> logger;

        public HashController(IHashFuncClient client, ILogger<HashController> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserCredential userCredential)
        {
            string key = $"{userCredential.Login}+{userCredential.Password}";
            string hashVal = await client.GetHash(key);
            HashResponse resp = new HashResponse()
            {
                hash_value = hashVal
            };

            return Ok(resp);
        }

        [HttpGet]
        public string Get()
        {
            return "test";
        }
    }
}
