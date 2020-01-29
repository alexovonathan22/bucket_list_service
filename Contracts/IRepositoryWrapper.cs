using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IBucketListRepository BucketList { get; }
        IItemRepository Item { get; }
        void Save();
    }
}
