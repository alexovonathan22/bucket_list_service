using Contracts;
using Entities;
using Entities.Models;
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
    }
}
