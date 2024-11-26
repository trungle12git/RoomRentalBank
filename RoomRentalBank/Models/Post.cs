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
        [Column("post_id")] // Chỉ định tên cột trong CSDL
        public int PostId { get; set; }

        [Column("user_id")] // Chỉ định tên cột trong CSDL
        public int UserId { get; set; }

        [Column("address")] // Chỉ định tên cột trong CSDL
        public string? Address { get; set; }

        [Column("description")] // Chỉ định tên cột trong CSDL
        public string? Description { get; set; }

        [Column("price")] // Chỉ định tên cột trong CSDL
        public int Price { get; set; }

        [Column("status")] // Chỉ định tên cột trong CSDL
        public int Status { get; set; }

        [Column("image_urls")] // Chỉ định tên cột trong CSDL
        public string? ImageUrls { get; set; }

        [Column("create_date")] // Chỉ định tên cột trong CSDL
        public DateTime CreationDate { get; set; }

        [Column("updated_date")] // Chỉ định tên cột trong CSDL
        public DateTime UpdationDate { get; set; }

        [Column("area")] // Chỉ định tên cột trong CSDL
        public decimal Area { get; set; }

        [Column("eaw_charges")] // Chỉ định tên cột trong CSDL
        public int EawCharge { get; set; }

        // Các liên kết với các đối tượng khác
        public required User User { get; set; }
        public required Feature Feature { get; set; }
    }
}
