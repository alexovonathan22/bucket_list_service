using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class BucketListForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string BucketListName { get; set; }

        [Required(ErrorMessage = "Date of goal creation is required")]
        public DateTime Date_Created { get; set; }

        [Required(ErrorMessage = "Providing your name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer then 100 characters")]
        public string Created_By { get; set; }
    }
}
