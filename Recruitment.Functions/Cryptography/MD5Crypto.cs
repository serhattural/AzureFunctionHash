using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Recruitment.Functions
{
    public class MD5Crypto : ICrypto
    {
        public String Encrypt(string value)
        {
            StringBuilder sb = new StringBuilder();

            using (var hash = MD5.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] hashedBytes = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in hashedBytes)
                    sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        public string Decrypt(string value)
        {
            throw new NotImplementedException();
        }
    }
}
