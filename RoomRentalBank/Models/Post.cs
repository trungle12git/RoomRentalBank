using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomRentalBank.Models
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public int UserId { get; set; }
        public required string Address { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public required string Status { get; set; }
        public string? ImageUrls { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdationDate { get; set; }
        public decimal Area { get; set; }
        public int EawCharge { get; set; }

        //
        public required User User { get; set; }
        public required Feature Feature { get; set; }
    }
}
