using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class BucketDto
    {
        public Guid BucketListId { get; set; }
        public string BucketListName { get; set; }

        public DateTime Date_Created { get; set; }

        public DateTime Date_Modified { get; set; }

        public string Created_By { get; set; }

        public IEnumerable<ItemDto> Items { get; set; }

    }
}
