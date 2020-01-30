using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IBucketListRepository BucketListWrapper { get; }
        IItemRepository ItemWrapper { get; }
        void Save();
    }
}
