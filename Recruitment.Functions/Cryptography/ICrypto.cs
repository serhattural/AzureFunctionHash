using System;  
using System.Collections.Generic;
using System.Text;

namespace Recruitment.Functions
{
    public interface ICrypto
    {
        string Encrypt(string key);
        string Decrypt(string value);
    }
}
