using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
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
        private IMapper _mapper;

        public BucketListController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllBuckets()
        {
            try
            {
                var buckets = _repository.BucketListWrapper.GetAllBuckets();
                _logger.LogInfo($"Returned all Buckets available in DB");

                var bucketsdtoResults = _mapper.Map<IEnumerable<BucketDto>>(buckets);
                return Ok(bucketsdtoResults);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("{id}", Name = "BucketListId")]
        public IActionResult GetBucketListById(Guid id)
        {
            try
            {
                var bucket = _repository.BucketListWrapper.GetBucketListById(id);

                if (bucket == null)
                {
                    _logger.LogError($"bucket with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned bucket with id: {id}");

                    var bucketResult = _mapper.Map<BucketDto>(bucket);
                    return Ok(bucketResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        //get all items in a bucket

        [HttpGet("{id}/item")]
        public IActionResult GetBucketItems(Guid id)
        {
            try
            {
                var bucket = _repository.BucketListWrapper.GetBucketItems(id);

                if(bucket == null)
                {
                    _logger.LogError($"Bucket with id: {id}, not found");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"return bucket with items for id: {id}");

                    //mapping results to send to view
                    var bucketResults = _mapper.Map<BucketDto>(bucket);
                    return Ok(bucketResults);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong getting bucket items {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //post req starts here

        [HttpPost]
        public IActionResult CreateBucket([FromBody]BucketListForCreationDto bucket)
        {
            try
            {
                if (bucket == null)
                {
                    _logger.LogError("Owner object sent from client is null.");
                    return BadRequest("Owner object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid owner object sent from client.");
                    return BadRequest("Invalid model object");
                }

                //first map from creaationDto
                var newbucketListEntity = _mapper.Map<BucketList>(bucket);

                _repository.BucketListWrapper.CreateBucket(newbucketListEntity);
                _repository.Save();

                //first map from bucketDto

                var createdBucket = _mapper.Map<BucketDto>(newbucketListEntity);
                //new { id = createdBucket.BucketListId }// did some change here
                return CreatedAtRoute("BucketListId", new { id = createdBucket.BucketListId }, createdBucket);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateOwner action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBucketList(Guid id, [FromBody]BucketListForUpdateDto bucket)
        {
            try
            {
                bucket.Date_Modified = DateTime.Now;
                if (bucket == null)
                {
                    _logger.LogError("bucket object sent from client is null.");
                    return BadRequest("bucket object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid bucket object sent from client.");
                    return BadRequest("Invalid model bucket");
                }

                var bucketEntity = _repository.BucketListWrapper.GetBucketListById(id);
                if (bucketEntity == null)
                {
                    _logger.LogError($"Bucket with id: {id}, hasn't been found.");
                    return NotFound();
                }

                _mapper.Map(bucket, bucketEntity);

                _repository.BucketListWrapper.UpdateBucketList(bucketEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside bucket action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //delete controller
        [HttpDelete("{id}")]
        public IActionResult DeleteBucket(Guid id)
        {
            try
            {
                var bucket = _repository.BucketListWrapper.GetBucketListById(id);
                if (bucket == null)
                {
                    _logger.LogError($"Bucket with id {id} not found");
                    return NotFound();
                }
                if (_repository.BucketListWrapper.BucketsWithItems(id).Any())
                {
                    _logger.LogError($"Cannot delete bucket with id: {id}. It has related item(s). Delete those item(s) first");
                    return BadRequest("Cannot delete bucket. It has related accounts. Delete those accounts first");
                }
                _repository.BucketListWrapper.DeleteBucket(bucket);
                _repository.Save();

                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteBucket action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}