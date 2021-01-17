using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using Recruitment.API.Clients;
using Recruitment.API.Controllers;
using Recruitment.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment.API.Controllers.Tests
{
    [TestFixture()]
    public class HashControllerTests
    {
        [Test()]
        public async Task PostActionResult_ReturnsNewlyCreatedHash()
        {
            // Arrange
            var userCredential = new UserCredential()
            {
                Login = "a",
                Password = "b"
            };
            string key = $"{userCredential.Login}+{userCredential.Password}";
            string hashValue = "65c884f742c8591808a121a828bc09f8";
            var hashFuncClient = new Mock<IHashFuncClient>();
            hashFuncClient.Setup(x => x.GetHash(key)).ReturnsAsync(hashValue);
            var logger = new Mock<ILogger<HashController>>();
            var controller = new HashController(hashFuncClient.Object, logger.Object);
            
            // Act
            var result = await controller.Post(userCredential);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<OkObjectResult>(result);

            var resultOk = (OkObjectResult)result;
            Assert.IsNotNull(resultOk.Value);
            Assert.IsInstanceOf<HashResponse>(resultOk.Value);

            var resp = (HashResponse)resultOk.Value;
            Assert.AreEqual(resp.hash_value, hashValue);
        }
    }
}