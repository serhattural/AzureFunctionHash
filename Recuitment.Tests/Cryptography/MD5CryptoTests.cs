using NUnit.Framework;
using Recruitment.Functions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recruitment.Functions.Tests
{
    [TestFixture()]
    public class MD5CryptoTests
    {
        [Test()]
        public void MD5Crypto_Encrypt_ShouldReturn_Expected()
        {
            // Arrange
            string key = "a+b";
            string expectedValue = "65c884f742c8591808a121a828bc09f8";
            ICrypto crypto = new MD5Crypto();

            // Act
            string value = crypto.Encrypt(key);

            // Assert
            Assert.IsNotNull(value);
            Assert.AreEqual(value, expectedValue);
        }
    }
}