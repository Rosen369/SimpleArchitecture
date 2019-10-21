using SimpleArchitecture.Abstractions.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleArchitecture.Abstractions.Service
{
    public interface ISampleService
    {
        Result DoSthByName(string name);
    }
}
