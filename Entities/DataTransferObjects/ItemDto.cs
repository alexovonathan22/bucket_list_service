using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ItemDto
    {
        public Guid ItemId { get; set; }
        
        public string Item_Name { get; set; }

        public DateTime Date_Created { get; set; }

        public DateTime Date_Modified { get; set; }

        public bool Done { get; set; }
    }
}
