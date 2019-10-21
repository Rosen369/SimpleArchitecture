using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonServiceLocator;
using Microsoft.AspNetCore.Mvc;
using SimpleArchitecture.Abstractions;
using SimpleArchitecture.Abstractions.Model;
using SimpleArchitecture.Abstractions.Service;

namespace SimpleArchitecture.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        [HttpGet]
        [ActionName("SampleGet")]
        public Result SomeMethod(string name)
        {
            try
            {
                var res = _sampleService.DoSthByName(name);
                return res;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                return new Result { Success = false, Message = ex.Message };
            }
        }

        [HttpPost]
        [ActionName("SamplePost")]
        public Result OtherMethod([FromBody] string value)
        {
            return new Result { Success = true };
        }

        private readonly ISampleService _sampleService = ServiceLocator.Current.GetInstance<ISampleService>();
        private readonly IAppLogger<SampleController> _logger = ServiceLocator.Current.GetInstance<IAppLogger<SampleController>>();
    }
}
