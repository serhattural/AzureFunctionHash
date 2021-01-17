using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.API.Clients
{
    public interface IHashFuncClient
    {
        Task<string> GetHash(string key);
    }
}
