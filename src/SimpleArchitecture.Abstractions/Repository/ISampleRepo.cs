using SimpleArchitecture.Abstractions.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleArchitecture.Abstractions.Repository
{
    public interface ISampleRepo
    {
        IList<SampleModel> GetByName(string name);
    }
}
