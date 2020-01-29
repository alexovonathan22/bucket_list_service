using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BucketListService.Controllers
{
    [Route("api/[controller]")] //base route
    [ApiController]
    public class BucketListController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;

        public BucketListController(ILoggerManager logger, IRepositoryWrapper repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAllBuckets()
        {
            try
            {
                var buckets = _repository.BucketList.GetAllBuckets();
                _logger.LogInfo($"Returned all Buckets available in DB");
                return Ok(buckets);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}