using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class BucketListRepository : RepositoryBase<BucketList>, IBucketListRepository
    {
        public BucketListRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<BucketList> GetAllBuckets()
        {
            return FindAll()
                    .OrderBy(bu => bu.BucketListName)
                    .ToList();
        }

        public BucketList GetBucketListById(Guid bucketlistId)
        {
            return FindByCondition(bucket => bucket.BucketListId.Equals(bucketlistId))
                    .FirstOrDefault();
        }

        public BucketList GetBucketItems(Guid bucketId)
        {
            return FindByCondition(bucket => bucket.BucketListId.Equals(bucketId))
                    .Include(it => it.Items)
                    .FirstOrDefault();
        }

        //post req

        public void CreateBucket(BucketList newBucket)
        {
            Create(newBucket);
        }

        //put req

        public void UpdateBucketList(BucketList UpdateBucketList)
        {
            Update(UpdateBucketList);
        }

        //delete req
        public void DeleteBucket(BucketList bucket) 
        {
            Delete(bucket);
        }

        public IEnumerable<BucketList> BucketsWithItems(Guid bucketId)
        {
            return FindByCondition(a => a.BucketListId.Equals(bucketId)).ToList();
        }
    }
}
