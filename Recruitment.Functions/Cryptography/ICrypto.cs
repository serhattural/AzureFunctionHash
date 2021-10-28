using System;   a
using System.Collections.Generic;  a
using System.Text;

namespace Recruitment.Functions
{
    public interface ICrypto
    {
        string Encrypt(string key);
        string Decrypt(string value);
    }
}
