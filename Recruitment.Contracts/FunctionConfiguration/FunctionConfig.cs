using Recruitment.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruitment.Contracts
{
    public class FunctionConfig
    {
        public Dictionary<string, FunctionOptions> MapOption { get; set; }
    }
}
