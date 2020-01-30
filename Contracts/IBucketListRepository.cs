using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IBucketListRepository : IRepositoryBase<BucketList>
    {
        IEnumerable<BucketList> GetAllBuckets();
        IEnumerable<BucketList> BucketsWithItems(Guid ownerId);
        BucketList GetBucketListById(Guid bucketlistId);
        BucketList GetBucketItems(Guid bucketId);

        void CreateBucket(BucketList newBucket);
        void UpdateBucketList(BucketList updateBucket);
        void DeleteBucket(BucketList delBucket);

    }
}
