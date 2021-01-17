using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Recruitment.Functions;
using Recuitment.Tests.Functions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.Functions.Tests
{
    [TestFixture()]
    public class HashFunctionTests
    {
        private readonly ILogger logger = TestFactory.CreateLogger();

        [Test()]
        public async Task Http_trigger_should_return_expected_string()
        {
            //Arrange
            string key = "a+b";
            string expectedValue = "65c884f742c8591808a121a828bc09f8";
            
            //Act
            var request = TestFactory.CreateHttpRequest("key", key);
            var response = (OkObjectResult)await HashFunction.Run(request, key, logger);
            
            //Assert
            Assert.AreEqual(expectedValue, response.Value);
        }
    }
}