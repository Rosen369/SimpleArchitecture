using CommonServiceLocator;
using SimpleArchitecture.Abstractions.Model;
using SimpleArchitecture.Abstractions.Repository;
using SimpleArchitecture.Abstractions.Service;
using System;

namespace SimpleArchitecture.Service
{
    public class SampleService : ISampleService
    {
        public Result DoSthByName(string name)
        {
            var sampleList = this._sampleRepo.GetByName(name);
            //do something
            return new Result { Success = true };
        }

        private readonly ISampleRepo _sampleRepo = ServiceLocator.Current.GetInstance<ISampleRepo>();
    }
}
