using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BucketListService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public WeatherForecastController(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }
     
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var items = _repositoryWrapper.Item.FindByCondition(x => x.Item_Name.Equals("Love God"));
            var buckets = _repositoryWrapper.BucketList.FindAll();

            return new string[] { "value1", "value2" };
        }

    }
}
