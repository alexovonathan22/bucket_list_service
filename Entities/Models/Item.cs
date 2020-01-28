using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("Item")]
    public class Item
    {
        public Guid ItemId { get; set; }

        [Required(ErrorMessage ="Title for what you want to achieve is required")]
        [StringLength(70, ErrorMessage =("Your goal cannot be more than 70 characters"))]
        public string Item_Name { get; set; }

        [Required(ErrorMessage = "Date created is required")]
        public DateTime Date_Created { get; set; }

        [Required(ErrorMessage = "Date goal updated type is required")]
        public DateTime Date_Modified { get; set; }

        public bool Done { get; set; }

        [ForeignKey(nameof(BucketList))]
        public Guid BucketListId { get; set; }
        public BucketList BucketList { get; set; }
    }
}