using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IBucketListRepository _bucketList;
        private IItemRepository _item;

        public IBucketListRepository BucketList
        {
            get
            {
                if (_bucketList == null)
                {
                    _bucketList = new BucketListRepository(_repoContext);
                }

                return _bucketList;
            }
        }

        public IItemRepository Item
        {
            get
            {
                if (_item == null)
                {
                    _item = new ItemRepository(_repoContext);
                }

                return _item;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }

}
